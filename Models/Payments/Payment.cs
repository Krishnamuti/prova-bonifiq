namespace ProvaPub.Models.Payments
{
    public abstract class Payment
    {
        public abstract Task<Order> PayOrder(decimal paymentValue, int customerId);
    }
}
