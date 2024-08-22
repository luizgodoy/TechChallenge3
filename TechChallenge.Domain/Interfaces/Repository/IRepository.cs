using System.Linq.Expressions;
using TechChallenge.Core.DTO;
using TechChallenge.Core.Models;

namespace TechChallenge.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(Guid id);

        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        ReturnTableDto<TType> GetRadzenList<TType>(string filter, string order, int? skip, int? take, Expression<Func<TEntity, TType>> select) where TType : class;

        Task<int> SaveChanges();
    }
}