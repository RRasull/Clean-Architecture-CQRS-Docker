using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture_CQRS_Docker.Application.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> exp = null, params string[] includes);

        List<TEntity> GetAll(Expression<Func<TEntity, bool>> exp = null, params string[] includes);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> exp = null, params string[] includes);
        TEntity Get(Expression<Func<TEntity, bool>> exp = null, params string[] includes);

        Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> exp = null);
        Task<List<TEntity>> Take(int number, Expression<Func<TEntity, bool>> exp = null, params string[] includes);


        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
