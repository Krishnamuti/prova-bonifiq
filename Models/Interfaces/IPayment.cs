namespace ProvaPub.Models.Interfaces
{
    public interface IPayment
    {
        Task<Order> PayOrder(decimal paymentValue, int customerId);
    }
}
