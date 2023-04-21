using ProvaPub.Models.Payments;
using ProvaPub.Models;

namespace ProvaPub.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> PayOrder(PaymentMethods paymentMethod, decimal paymentValue, int customerId);
    }
}
