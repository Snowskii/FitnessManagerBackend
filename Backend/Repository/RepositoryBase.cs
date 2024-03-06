using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace backend.Repository
{
    public abstract class RepositoryBase<T> : Interfaces.IRepositoryBase<T> where T: class 
    {
        protected ApplicationDataContext ApplicationDataContext { get; set; }

        protected RepositoryBase(ApplicationDataContext dbContext)
        {
            ApplicationDataContext = dbContext;
        }

        public IQueryable<T> FindAll() => ApplicationDataContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            ApplicationDataContext.Set<T>().Where(expression).AsNoTracking();
        public T Create(T entity) => ApplicationDataContext.Set<T>().Add(entity).Entity;
        public T Update(T entity) => ApplicationDataContext.Set<T>().Update(entity).Entity;
        public void Delete(T entity) => ApplicationDataContext.Set<T>().Remove(entity);
    }
}
