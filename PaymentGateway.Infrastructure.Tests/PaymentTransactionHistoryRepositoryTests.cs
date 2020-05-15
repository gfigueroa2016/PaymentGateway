using System;
using System.Linq;
using System.Threading.Tasks;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Fixtures;
using PaymentGateway.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace PaymentGateway.Infrastructure.Tests
{
    public class PaymentTransactionHistoryRepositoryTests : IClassFixture<PaymentGatewayContextFactory>
    {
        private readonly PaymentTransactionHistoryRepository _sut;
        private readonly TestPaymentGatewayContext _paymentGatewayContext;
        public PaymentTransactionHistoryRepositoryTests(PaymentGatewayContextFactory paymentGatewayContextFactory)
        {
            _paymentGatewayContext = paymentGatewayContextFactory.ContextInstance;
            _sut = new PaymentTransactionHistoryRepository(_paymentGatewayContext);
        }
        [Fact]
        public async Task Should_Get_Data()
        {
            var result = await _sut.GetAsync();
            result.ShouldNotBeNull();
        }
        [Fact]
        public async Task Should_Returns_Empty_With_Invoice_Not_Present()
        {
            var result = await _sut.GetAsync(null, null);
            result.ShouldBeNull();
        }
        [Theory]
        [InlineData("b5b055349263448ca69e0bbd8b3eb90u")]
        public async Task Should_Return_Record_By_Invoice(string guid)
        {
            var result = await _sut.GetAsync(null, guid);
            result.FirstOrDefault().Invoice.ShouldBe(guid);
        }
        [Fact]
        public async Task Should_Add_New_PaymentTransactionHistory()
        {
            var testPaymentTransactionHistory = new PaymentTransactionHistory
            {
                Amount = Convert.ToDecimal("1337.17"),
                CustomerId = Guid.NewGuid().ToString(),
                Invoice = Guid.NewGuid().ToString(),
                Tax = Convert.ToDecimal("337.17"),
                Transaction_Detail = "Payment Transaction Test",
            };
            _sut.Add(testPaymentTransactionHistory);
            await _sut.UnitOfWork.SaveEntitiesAsync();
            _paymentGatewayContext.PaymentTransactionsHistory.FirstOrDefault(x => x.Invoice == testPaymentTransactionHistory.Invoice).ShouldNotBeNull();
        }
        [Fact]
        public async Task Should_Update_PaymentTransactionHistory()
        {
            var testPaymentTransactionHistory = new PaymentTransactionHistory
            {
                Amount = Convert.ToDecimal("1337.17"),
                CustomerId = Guid.NewGuid().ToString(),
                Invoice = "b5b055349263448ca69e0bbd8b3eb90u",
                Tax = Convert.ToDecimal("337.17"),
                Transaction_Detail = "Payment Transaction Test 2",
            };
            _sut.Update(testPaymentTransactionHistory);
            await _sut.UnitOfWork.SaveEntitiesAsync();
            _paymentGatewayContext.PaymentTransactionsHistory.FirstOrDefault(x => x.Invoice == testPaymentTransactionHistory.Invoice)?.Transaction_Detail.ShouldBe("Payment Transaction Test 2");
        }
    }
}
