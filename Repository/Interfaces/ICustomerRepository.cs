using ProvaPub.Models;

namespace ProvaPub.Repository.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer?> GetById(int id);
        Task<int> CountAsyncByCustomerIdOrders(int customerId);
    }
}
