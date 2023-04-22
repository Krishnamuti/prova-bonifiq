using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository.Interfaces;

namespace ProvaPub.Repository
{
    public class OrderRepository : GenericRepository<Customer>, IOrderRepository
    {
        public OrderRepository(TestDbContext dbContext) : base(dbContext) { }

        public async Task<int> CountAsyncByCustomerIdOrderDate(int customerId, DateTime baseDate)
        {
            return await _ctx.Orders.CountAsync(s => s.CustomerId == customerId && s.OrderDate >= baseDate);
        }

    }
}
