using System.Linq.Expressions;
using TechChallenge.Core.DTO;
using TechChallenge.Domain.Models;

namespace TechChallenge.Domain.Interfaces
{
    public interface IContactService
    {
        Task Create (Contact contact);
        Task Delete (Guid id);
        Task Update (Contact contact);

        Task<Contact> GetById (Guid id);
        Task<IEnumerable<Contact>> GetAll ();
        ReturnTableDto<Contact> GetRadzenList(string filter, string order, int? skip, int? take, Expression<Func<Contact, Contact>> select);
    }
}