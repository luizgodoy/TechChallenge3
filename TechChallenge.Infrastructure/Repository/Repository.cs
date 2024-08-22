using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using TechChallenge.Core.DTO;
using TechChallenge.Core.Models;
using TechChallenge.Data.Context;
using TechChallenge.Domain.Interfaces;

namespace TechChallenge.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {

        protected readonly techchallengeDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(techchallengeDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }
        public virtual async Task Create(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Delete(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public ReturnTableDto<TType> GetRadzenList<TType>(string filter, string order, int? skip, int? take, Expression<Func<TEntity, TType>> select) where TType : class
        {
            var response = new ReturnTableDto<TType>();
            var query = from obj in DbSet select obj;

            response.TotalRegister = query.Count();

            if (!string.IsNullOrEmpty(filter))
                query = query.Where(filter);

            if (!string.IsNullOrEmpty(order))
                query = query.OrderBy(order);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);
            response.List = query.Select(select).ToList();
            response.TotalRegisterFilter = query.Count();

            return response;
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();

        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
        }
    }
}