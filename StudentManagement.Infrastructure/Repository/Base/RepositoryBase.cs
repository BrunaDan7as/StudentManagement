using Microsoft.EntityFrameworkCore;
using StudentManagement.Domain.Interfaces.Repository.Base;
using StudentManagement.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Infrastructure.Repository.Base
{
    public class RepositoryBase <TEntity, TId> : IRepositoryBase<TEntity, TId>
           where TEntity : BaseModel
           where TId : struct
    {
        private readonly DbContext _context;
        public RepositoryBase(DbContext context)
        {
            _context = context;
        }
        public TEntity Add(TEntity entidade)
        {
            _context.Set<TEntity>().Add(entidade);
            _context.SaveChanges();
            return entidade;
        }
        
        public void Delete(TEntity entidade)
        {
            _context.Set<TEntity>().Remove(entidade);
            _context.SaveChanges();
        }
        public TEntity Update(TEntity entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;
            _context.SaveChanges();
            return entidade;
        }
        public bool Exists(Func<TEntity, bool> where) => _context.Set<TEntity>().Any(where);
        public IQueryable<TEntity> ListWhere(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties) => List(includeProperties).Where(where);
        public IQueryable<TEntity> List(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (includeProperties.Any()) return Include(_context.Set<TEntity>(), includeProperties);
            return query;
        }
        private IQueryable<TEntity> Include(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            foreach (var property in includeProperties) query = query.Include(property);
            return query;
        }

        public TEntity GetBy(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] includeProperties) => List(includeProperties).FirstOrDefault(where);
        public void Dispose() => _context.Dispose();
    }
}
