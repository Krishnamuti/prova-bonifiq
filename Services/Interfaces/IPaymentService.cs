using ProvaPub.Models.Payments;

namespace ProvaPub.Services.Interfaces
{
    public interface IPaymentService
    {
        Payment GetPaymentMethod(PaymentMethods paymentMethod);
    }
}
