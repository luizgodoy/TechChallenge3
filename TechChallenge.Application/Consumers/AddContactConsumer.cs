using System.Threading.Tasks;
using AutoMapper;
using MassTransit;
using TechChallenge.Contract.Contact;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.Models;

namespace TechChallenge.Application.Consumers
{
    public class AddContactConsumer : IConsumer<AddContactMessage>
    {
        private readonly IMapper _mapper; 
        private readonly IContactService _contactService;
        
        public AddContactConsumer(IMapper mapper, IContactService contactService)
        {
            _mapper = mapper;
            _contactService = contactService;
        }   
        
        public async Task Consume(ConsumeContext<AddContactMessage> context)
        {
            var addContactMessage = context.Message;
            var addContact = _mapper.Map<Contact>(addContactMessage);
            await _contactService.Create(addContact);
        }
    }
}