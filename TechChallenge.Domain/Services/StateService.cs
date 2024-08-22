using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.Models;

namespace TechChallenge.Domain.Services;

public class StateService : IStateService
{
    private readonly IStateRepository _stateRepository;

    public StateService(IStateRepository stateRepository)
    {
        _stateRepository = stateRepository;
    }

    public async Task<IEnumerable<State>> GetAll()
    {
        return await _stateRepository.GetAll();
    }

    public async Task<State> GetByDDD(int ddd)
    {
        return await _stateRepository.GetByDDD(ddd);
    }

    public async Task<State> GetById(Guid id)
    {
        return await _stateRepository.GetById(id);
    }
}
