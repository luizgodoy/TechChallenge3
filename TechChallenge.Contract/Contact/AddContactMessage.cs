using TechChallenge.Domain.Models;

namespace TechChallenge.Contract.Contact
{
    public record AddContactMessage
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid StateId { get; set; }
        public State? State { get; set; }
    }
}