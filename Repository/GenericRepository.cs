using Microsoft.EntityFrameworkCore;
using ProvaPub.Repository.Interfaces;

namespace ProvaPub.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly TestDbContext _dbContext;

        public GenericRepository(TestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetPaginate(int page, int limitOfPage)
        {
            return _dbContext.Set<TEntity>().AsNoTracking().Skip(((page <= 0 ? 1 : page) * limitOfPage) - limitOfPage).Take(limitOfPage);
        }
    }
}
