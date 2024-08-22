using TechChallenge.Core.DTO;

namespace TechChallenge.Web.WebServices.Interfaces;
public interface IStateWebService
{
    Task<IEnumerable<StateDto>> GetAllStates();
    Task<StateDto?> GetStateByDDD(int ddd);
    Task<StateDto?> GetStateById(Guid id);
}
