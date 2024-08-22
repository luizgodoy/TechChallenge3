using TechChallenge.Core.Models;

namespace TechChallenge.Domain.Models
{
    public class Contact : Entity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid StateId { get; set; }
        //EF RELATION 
        public State? State { get; set; }
    }
}
