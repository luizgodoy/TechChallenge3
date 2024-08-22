using Microsoft.EntityFrameworkCore;
using TechChallenge.Data.Context;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.Models;
using TechChallenge.Infrastructure.Repository;

namespace TechChallenge.Data.Repository
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(techchallengeDbContext dbContext) : base(dbContext)
        {

        }
        
        public  async Task<IEnumerable<Contact>> GetAll()
        {
            return await Db.Contacts.Include(d => d.State).OrderBy(c => c.Name).ToListAsync();  
        }

        public override async Task<Contact> GetById(Guid id)
        {
            return Db.Set<Contact>().SingleOrDefault(c => c.Id == id);
        }
    }
}
