using Microsoft.EntityFrameworkCore;
using TechChallenge.Data.Context;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.Models;
using TechChallenge.Infrastructure.Repository;

namespace TechChallenge.Data.Repository;

public class StateRepository : Repository<State>, IStateRepository
{
    public StateRepository(techchallengeDbContext db) : base(db)
    {
    }

    public async Task<IEnumerable<State>> GetAll()
    {
        return await Db.States.Include(d => d.Contacts).OrderBy(c => c.Name).ToListAsync();
    }

    public override async Task<State> GetById(Guid id)
    {
        return await Db.States.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<State> GetByDDD(int ddd)
    {
        return await DbSet.FirstOrDefaultAsync(s => s.DDD == ddd); ;
    }
}
