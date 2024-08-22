using TechChallenge.Domain.Models;

namespace TechChallenge.Domain.Interfaces;

public interface IStateService
{
    Task<State> GetByDDD(int ddd);
    Task<State> GetById(Guid id);
    Task<IEnumerable<State>> GetAll();
}
