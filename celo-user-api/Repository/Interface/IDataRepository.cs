using celo_user_api.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace celo_user_api.Repository
{
    public interface IDataRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        TEntity Get(int id);
        IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression);
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
    }
}

