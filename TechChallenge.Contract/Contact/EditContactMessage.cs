using TechChallenge.Domain.Models;

namespace TechChallenge.Contract.Contact
{
    public record EditContactMessage
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public State? State { get; set; }
    }
}