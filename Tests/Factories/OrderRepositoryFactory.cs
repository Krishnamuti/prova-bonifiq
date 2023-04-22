namespace ProvaPub.Tests.Factories
{
    public class OrderRepositoryFactory
    {
        public int GetOrdersInThisMonthInvalid() => 10;

        public int GetOrdersInThisMonthValid() => 0;
    }
}
