using celo_user_api.Models;
using celo_user_api.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace celo_user_api.Repository
{
    public class DataRepository<TEntity> : IDataRepository<TEntity> where TEntity : class, IEntity
    {
        readonly UserDBContext _userContext;
        public DataRepository(UserDBContext context)
        {
            _userContext = context;
            context.Database.EnsureCreated();
        }


        public IQueryable<TEntity> GetAll()
        {
            return _userContext.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            return _userContext.Set<TEntity>().SingleOrDefault(e => e.Id == id);
        }

        public IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return _userContext.Set<TEntity>().Where(expression);
        }

        public bool Add(TEntity entity)
        {
            _userContext.Set<TEntity>().Add(entity);
            _userContext.SaveChanges();
            return true;
        }

        public bool Update(TEntity entity)
        {
            _userContext.Set<TEntity>().Update(entity);
            _userContext.SaveChanges();
            return true;
        }

        public bool Delete(TEntity entity)
        {
            _userContext.Set<TEntity>().Remove(entity);
            _userContext.SaveChanges();
            return true;
        }
    }
}
