using System.Threading.Tasks;
using MassTransit;
using TechChallenge.Contract.Contact;
using TechChallenge.Domain.Interfaces;

namespace TechChallenge.Application.Consumers
{
    public class DeleteContactConsumer : IConsumer<DeleteContactMessage>
    {
        private readonly IContactService _contactService;

        public DeleteContactConsumer(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task Consume(ConsumeContext<DeleteContactMessage> context)
        {
            var deleteContactMessage = context.Message;
            await _contactService.Delete(deleteContactMessage.ContactId);
        }
    }
}