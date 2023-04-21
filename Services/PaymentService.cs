using ProvaPub.Models.Payments.Methods;
using ProvaPub.Models.Payments;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services
{
    public class PaymentService : IPaymentService
    {
        public PaymentService()
        {

        }

        public Payment GetPaymentMethod(PaymentMethods paymentMethod)
        {
            switch (paymentMethod)
            {
                case PaymentMethods.PIX:
                    return new Pix();
                case PaymentMethods.CREDITCARD:
                    return new CreditCard();
                case PaymentMethods.PAYPAL:
                    return new Paypal();
                default:
                    break;
            }
            throw new Exception("Forma de pagamento não implementada");
        }
    }
}
