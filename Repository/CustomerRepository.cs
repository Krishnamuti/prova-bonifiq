using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository.Interfaces;

namespace ProvaPub.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(TestDbContext dbContext) : base(dbContext) { }

        public async Task<Customer?> GetById(int id)
        {
            return await _ctx.Customers.FindAsync(id);
        }

        public async Task<int> CountAsyncByCustomerIdOrders(int customerId)
        {
            return await _ctx.Customers.CountAsync(s => s.Id == customerId && s.Orders.Any());
        }
    }
}
