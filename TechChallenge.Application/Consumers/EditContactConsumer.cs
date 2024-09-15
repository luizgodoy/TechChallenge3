using System.Threading.Tasks;
using AutoMapper;
using MassTransit;
using TechChallenge.Contract.Contact;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.Models;

namespace TechChallenge.Application.Consumers
{
    public class EditContactConsumer : IConsumer<EditContactMessage>
    {
        private readonly IMapper _mapper;
        private readonly IContactService _contactService;

        public EditContactConsumer(IMapper mapper,IContactService contactService)
        {
            _mapper = mapper;
            _contactService = contactService;
        }

        public async Task Consume(ConsumeContext<EditContactMessage> context)
        {
            var updateContactMessage = context.Message;
            var updateContact = _mapper.Map<Contact>(updateContactMessage);
            await _contactService.Update(updateContact);
        }
    }
}