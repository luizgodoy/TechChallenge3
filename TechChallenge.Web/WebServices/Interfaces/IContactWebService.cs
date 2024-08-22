using Radzen;
using TechChallenge.Core.DTO;

namespace TechChallenge.Web.WebServices.Interfaces;

public interface IContactWebService
{
    Task<ContactDto?> GetById(Guid id);
    Task<IEnumerable<ContactDto>> GetAll();
    Task<ReturnTableDto<ContactDto>> GetRadzenList(LoadDataArgs args);
    Task<ContactDto?> AddContact(ContactDto contact);
    Task<ContactDto?> Update(ContactDto contact);
    Task<bool> Delete(Guid id);
}
