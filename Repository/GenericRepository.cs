using Microsoft.EntityFrameworkCore;
using ProvaPub.Repository.Interfaces;

namespace ProvaPub.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected TestDbContext _ctx;

        public GenericRepository(TestDbContext dbContext)
        {
            _ctx = dbContext;
        }

        public IQueryable<TEntity> GetPaginate(int page, int limitPerPage)
        {
            return _ctx.Set<TEntity>().AsNoTracking().Skip(((page <= 0 ? 1 : page) * limitPerPage) - limitPerPage).Take(limitPerPage);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _ctx.Set<TEntity>().AsNoTracking();
        }
    }
}
