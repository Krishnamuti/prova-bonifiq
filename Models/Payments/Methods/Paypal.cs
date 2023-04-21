namespace ProvaPub.Models.Payments.Methods
{
    public class Paypal : Payment
    {
        public override async Task<Order> PayOrder(decimal paymentValue, int customerId)
        {
            return await Task.FromResult(new Order()
            {
                Value = paymentValue
            });
        }
    }
}
