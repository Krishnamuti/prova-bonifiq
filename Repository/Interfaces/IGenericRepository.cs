using System.Security.Principal;

namespace ProvaPub.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetPaginate(int page, int limitOfPage);
    }
}
