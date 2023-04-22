using Bogus;
using ProvaPub.Models;

namespace ProvaPub.Tests.Factories
{
    public class CustomerRepositoryFactory
    {
        public async Task<Customer?> GetCustomerNull()
        {
            return await Task.FromResult((Customer?)null);
        }

        public async Task<Customer?> GetCustomerValid()
        {
            return await Task.FromResult(new Customer()
            {
                Id = 1,
                Name = new Faker().Person.FullName,
            });
        }

        public int GetHaveBoughtBeforeValid() => 10;

        public int GetHaveBoughtBeforeInvalid() => 0;
    }
}
