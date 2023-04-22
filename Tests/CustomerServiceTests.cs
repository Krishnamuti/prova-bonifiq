using Moq;
using ProvaPub.Repository.Interfaces;
using ProvaPub.Services;
using ProvaPub.Tests.Factories;
using Xunit;

namespace ProvaPub.Tests
{

    public class CustomerServiceTests
    {
        [Fact]
        public async Task CanPurchase_CustomerIdPurchaseValueInvalid_ReturnArgumentOutOfRangeException()
        {

            //Arrange
            var customerRepository = new Mock<ICustomerRepository>();
            var orderRepository = new Mock<IOrderRepository>();            
            var customerService = new CustomerService(customerRepository.Object, orderRepository.Object);

            //Act
            Task act1() => customerService.CanPurchase(0, 0);
            Task act2() => customerService.CanPurchase(-1, -1);
            Task act3() => customerService.CanPurchase(1, 0);
            Task act4() => customerService.CanPurchase(0, 1);

            //Asserts
            await Assert.ThrowsAnyAsync<ArgumentOutOfRangeException>(act1);
            await Assert.ThrowsAnyAsync<ArgumentOutOfRangeException>(act2);
            await Assert.ThrowsAnyAsync<ArgumentOutOfRangeException>(act3);
            await Assert.ThrowsAnyAsync<ArgumentOutOfRangeException>(act4);
        }

        [Fact]
        public async Task CanPurchase_CustomerNull_ReturnInvalidOperationException()
        {

            //Arrange
            var customerRepository = new Mock<ICustomerRepository>();
            var orderRepository = new Mock<IOrderRepository>();

            int customerId = 1;
            decimal purchaseValue = 1;
            var customerNull = new CustomerRepositoryFactory().GetCustomerNull();
            customerRepository.Setup(cr => cr.GetById(customerId)).Returns(customerNull);
            var customerService = new CustomerService(customerRepository.Object, orderRepository.Object);

            //Act
            Task act() => customerService.CanPurchase(customerId, purchaseValue);

            //Assert
            await Assert.ThrowsAnyAsync<InvalidOperationException>(act);
        }

        [Fact]
        public async Task CanPurchase_CountCustomerOrdersDateInvalid_ReturnFalse()
        {

            //Arrange
            var customerRepository = new Mock<ICustomerRepository>();
            var orderRepository = new Mock<IOrderRepository>();

            int customerId = 1;
            decimal purchaseValue = 100;
            var customer = new CustomerRepositoryFactory().GetCustomerValid();
            var baseDate = DateTime.UtcNow.AddMonths(-1);
            customerRepository.Setup(cr => cr.GetById(customerId)).Returns(customer);

            int ordersInThisMonth = new OrderRepositoryFactory().GetOrdersInThisMonthInvalid();
            orderRepository.Setup(or => or.CountAsyncByCustomerIdOrderDate(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(Task.FromResult(ordersInThisMonth));

            var customerService = new CustomerService(customerRepository.Object, orderRepository.Object);

            //Act
            var result = await customerService.CanPurchase(customerId, purchaseValue);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task CanPurchase_CountCustomerOrdersPurchaseValueInvalid_ReturnFalse()
        {

            //Arrange
            var customerRepository = new Mock<ICustomerRepository>();
            var orderRepository = new Mock<IOrderRepository>();

            int customerId = 1;
            decimal purchaseValue = 101;
            var customer = new CustomerRepositoryFactory().GetCustomerValid();
            var baseDate = DateTime.UtcNow.AddMonths(-1);
            customerRepository.Setup(cr => cr.GetById(customerId)).Returns(customer);

            int ordersInThisMonth = new OrderRepositoryFactory().GetOrdersInThisMonthValid();
            orderRepository.Setup(or => or.CountAsyncByCustomerIdOrderDate(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(Task.FromResult(ordersInThisMonth));

            var haveBoughtBefore = new CustomerRepositoryFactory().GetHaveBoughtBeforeInvalid();
            customerRepository.Setup(cr => cr.CountAsyncByCustomerIdOrders(It.IsAny<int>())).Returns(Task.FromResult(haveBoughtBefore));

            var customerService = new CustomerService(customerRepository.Object, orderRepository.Object);

            //Act
            var result = await customerService.CanPurchase(customerId, purchaseValue);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task CanPurchase_ParametersValid_ReturnTrue()
        {

            //Arrange
            var customerRepository = new Mock<ICustomerRepository>();
            var orderRepository = new Mock<IOrderRepository>();

            int customerId = 1;
            decimal purchaseValue = 50;
            var customer = new CustomerRepositoryFactory().GetCustomerValid();
            var baseDate = DateTime.UtcNow.AddMonths(-1);
            customerRepository.Setup(cr => cr.GetById(customerId)).Returns(customer);

            int ordersInThisMonth = new OrderRepositoryFactory().GetOrdersInThisMonthValid();
            orderRepository.Setup(or => or.CountAsyncByCustomerIdOrderDate(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(Task.FromResult(ordersInThisMonth));

            var haveBoughtBefore = new CustomerRepositoryFactory().GetHaveBoughtBeforeValid();
            customerRepository.Setup(cr => cr.CountAsyncByCustomerIdOrders(It.IsAny<int>())).Returns(Task.FromResult(haveBoughtBefore));

            var customerService = new CustomerService(customerRepository.Object, orderRepository.Object);

            //Act
            var result = await customerService.CanPurchase(customerId, purchaseValue);

            //Assert
            Assert.True(result);
        }
    }
}
