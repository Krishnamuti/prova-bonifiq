using ProvaPub.Models.Interfaces;
using ProvaPub.Models.Payments;

namespace ProvaPub.Services.Interfaces
{
    public interface IPaymentService
    {
        IPayment GetPaymentMethod(PaymentMethods paymentMethod);
    }
}
