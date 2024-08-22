using TechChallenge.Core.Models;
using TechChallenge.Domain.Models;

namespace TechChallenge.Domain.Interfaces
{
    public interface IStateRepository : IRepository<State>
    {
        Task<State> GetByDDD(int ddd);
    }
}
