using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Context;
using System.Linq.Expressions;

namespace Repositories.EFCore.Models
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext _context;

        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Edit(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges
                   ? _context.Set<T>().AsNoTracking()
                   : _context.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool trackChanges)
        {
            return !trackChanges
                   ? _context.Set<T>().Where(condition).AsNoTracking()
                   : _context.Set<T>().Where(condition);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
