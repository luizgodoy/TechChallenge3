using AutoMapper;
using FluentValidation;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Radzen;
using TechChallenge.Contract.Contact;
using TechChallenge.Core.DomainExceptions;
using TechChallenge.Core.DTO;
using TechChallenge.Data.Repository;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.Models;
using TechChallenge.Domain.Validators;

namespace TechChallenge.API.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IStateService _stateService;
        private readonly IMapper _mapper;
        private readonly IBus _eventBus;

        public ContactController(IContactService contactService, IMapper mapper, IStateService stateService, IBus eventBus)
        {
            _mapper = mapper;
            _contactService = contactService;
            _stateService = stateService;
            _eventBus = eventBus;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("list-contact")]
        public async Task<IActionResult> GetAllContacts()
        {
            try
            {
               return Ok(_mapper.Map<IEnumerable<ContactDto>>(await _contactService.GetAll()));
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("radzen-list")]
        public IActionResult GetRadzenList(LoadDataArgs args)
        {
            try
            {
                var entity =  _contactService.GetRadzenList(args.Filter, args.OrderBy, args.Skip.Value, args.Top.Value, x => new Contact()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    State = x.State,
                    StateId = x.StateId
                });

                var dtoList = _mapper.Map<IEnumerable<ContactDto>>(entity.List);

                var returnTable = new ReturnTableDto<ContactDto>
                {
                    TotalRegister = entity.TotalRegister,
                    List = dtoList,
                    TotalPages = entity.TotalPages,
                    TotalRegisterFilter = entity.TotalRegisterFilter,
                };

               return Ok(returnTable);
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        [Route("register-contact")]
        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] ContactDto contact)
        {
            try
            {
                contact = await FillState(contact);
                var addContactMessage = _mapper.Map<AddContactMessage>(contact);

                await _eventBus.Publish(addContactMessage, context => context.SetRoutingKey("add.contact"));

                return Ok(contact);
            }
            catch (DomainException e)
            {
                return (BadRequest(new { Message = e.Message }));
            }
        }

        [HttpDelete]
        [Route("delete-contact/{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var contact = await _contactService.GetById(id);

            if (contact is null)
            {
                return NotFound();
            }

            var deleteContactMessage = new DeleteContactMessage
            {
                ContactId = id
            };
            
            await _eventBus.Publish(deleteContactMessage, context => context.SetRoutingKey("delete.contact"));

            return Ok();
        }

        [HttpPatch]
        [Route("update-contact")]
        public async Task<IActionResult> UpdateContact([FromBody] ContactDto dto)
        {
            //TODO: fluent validion
            var contact = await _contactService.GetById(dto.Id);

            if (contact is null)
            {
                return NotFound();
            }
            try
            {
                dto = await FillState(dto);
                var updateContactMessage = _mapper.Map<EditContactMessage>(dto);
                await _eventBus.Publish(updateContactMessage,context => context.SetRoutingKey("update.contact"));

            }
            catch (Exception e)
            {
                return (BadRequest(new { Message = e.Message }));
            }

            return Ok(dto);
        }


        private async Task<ContactDto> FillState(ContactDto contact)
        {
            contact.State =  _mapper.Map<StateDto>(await _stateService.GetById(contact.StateId));

            return contact;
        }
    }
}
