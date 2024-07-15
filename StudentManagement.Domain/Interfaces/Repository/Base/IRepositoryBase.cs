using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Domain.Interfaces.Repository.Base
{
    public interface IRepositoryBase <TEntity, in TId> : IDisposable where TEntity : class where TId : struct
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        bool Exists(Func<TEntity, bool> where);
        IQueryable<TEntity> ListWhere(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
