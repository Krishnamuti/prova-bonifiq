using ProvaPub.Models.Payments.Methods;
using ProvaPub.Models.Payments;
using ProvaPub.Services.Interfaces;
using ProvaPub.Models.Interfaces;

namespace ProvaPub.Services
{
    public class PaymentService : IPaymentService
    {
        public PaymentService()
        {

        }

        private IPayment payment;

        private void SetPayment(IPayment _payment)
        {
            payment = _payment;
        }

        public IPayment GetPaymentMethod(PaymentMethods paymentMethod)
        {

            switch (paymentMethod)
            {
                case PaymentMethods.PIX:
                    SetPayment(Pix);
                case PaymentMethods.CREDITCARD:
                    payment = new CreditCard();
                case PaymentMethods.PAYPAL:
                    payment = new Paypal();
                default:
                    throw new Exception("Forma de pagamento não implementada");
            }
            return payment;
        }
    }
}
