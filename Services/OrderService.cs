using ProvaPub.Models;
using ProvaPub.Models.Payments;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services
{
    public class OrderService : IOrderService
    {
        
        private readonly IPaymentService _paymentService;

        public OrderService(IPaymentService paymentService) 
        {
            _paymentService = paymentService;
        }

		public async Task<Order> PayOrder(PaymentMethods paymentMethod, decimal paymentValue, int customerId)
		{
            var payment = _paymentService.GetPaymentMethod(paymentMethod);
            return await payment.PayOrder(paymentValue, customerId);
		}        
    }
}