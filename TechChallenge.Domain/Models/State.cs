using TechChallenge.Core.Models;

namespace TechChallenge.Domain.Models
{
    public class State : Entity
    {
        public int DDD { get; set; }

        public string Name { get; set; }

        // EF Relations
        public IEnumerable<Contact> Contacts { get; set; }

    }
}
