namespace ProvaPub.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> CountAsyncByCustomerIdOrderDate(int customerId, DateTime baseDate);
    }
}
