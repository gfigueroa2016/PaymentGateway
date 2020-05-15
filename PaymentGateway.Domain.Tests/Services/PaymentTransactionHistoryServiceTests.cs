using PaymentGateway.Domain.Mappers;
using PaymentGateway.Domain.Repositories;
using PaymentGateway.Domain.Requests.PaymentTransactionHistory;
using PaymentGateway.Domain.Services;
using PaymentGateway.Fixtures;
using PaymentGateway.Infrastructure.Repositories;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PaymentGateway.Domain.Tests.Services
{
    public class PaymentTransactionHistoryServiceTests : IClassFixture<PaymentGatewayContextFactory>
    {
        private readonly IPaymentTransactionHistoryRepository _paymentTransactionHistoryRepository;
        private readonly IPaymentTransactionHistoryMapper _paymentTransactionHistoryMapper;
        public PaymentTransactionHistoryServiceTests(PaymentGatewayContextFactory paymentGatewayContextFactory)
        {
            _paymentTransactionHistoryRepository = new PaymentTransactionHistoryRepository(paymentGatewayContextFactory.ContextInstance);
            _paymentTransactionHistoryMapper = paymentGatewayContextFactory.PaymentTransactionHistoryMapper;
        }
        [Fact]
        public async Task GetPaymentTransactionsHistory_Should_Return_Right_Data()
        {
            IPaymentTransactionHistoryService sut = new PaymentTransactionHistoryService(_paymentTransactionHistoryRepository, _paymentTransactionHistoryMapper);
            var result = await sut.GetPaymentTransactionHistoryAsync();
            result.ShouldNotBeNull();
        }
        [Theory]
        [InlineData("b5b055349263448ca69e0bbd8b3eb90u")]
        public async Task GetPaymentTransactionHistory_Should_Return_Right_Data(string guid)
        {
            IPaymentTransactionHistoryService sut = new PaymentTransactionHistoryService(_paymentTransactionHistoryRepository, _paymentTransactionHistoryMapper);
            var result = await sut.GetPaymentTransactionHistoryAsync(new GetPaymentTransactionHistoryRequest { CustomerId = Guid.NewGuid().ToString(), Invoice = guid });
            result.FirstOrDefault().Invoice.ShouldBe(guid);
        }
        [Fact]
        public void GetPaymentTransactionHistory_Should_Thrown_Exception_With_Null_Id()
        {
            IPaymentTransactionHistoryService sut = new PaymentTransactionHistoryService(_paymentTransactionHistoryRepository, _paymentTransactionHistoryMapper);
            sut.GetPaymentTransactionHistoryAsync(null).ShouldThrow<ArgumentNullException>();
        }
        [Fact]
        public async Task AddPaymentTransactionHistory_Should_Add_Right_Entity()
        {
            var testPaymentTransactionHistory = new AddPaymentTransactionHistoryRequest
            {
                Amount = Convert.ToDecimal("1337.17"),
                CustomerId = Guid.NewGuid().ToString(),
                Invoice = Guid.NewGuid().ToString(),
                Tax = Convert.ToDecimal("337.17"),
                Transaction_Detail = "Payment Transaction History Test",
            };
            IPaymentTransactionHistoryService sut = new PaymentTransactionHistoryService(_paymentTransactionHistoryRepository, _paymentTransactionHistoryMapper);
            var result = await sut.AddPaymentTransactionHistoryAsync(testPaymentTransactionHistory);
            result.Amount.ShouldBe(testPaymentTransactionHistory.Amount);
            result.CustomerId.ShouldBe(testPaymentTransactionHistory.CustomerId);
            result.Invoice.ShouldBe(testPaymentTransactionHistory.Invoice);
            result.Tax.ShouldBe(testPaymentTransactionHistory.Tax);
            result.Transaction_Detail.ShouldBe(testPaymentTransactionHistory.Transaction_Detail);
        }
        [Fact]
        public async Task EditPaymentTransactionHistory_Should_Add_Right_Entity()
        {
            var testPaymentTransactionHistory = new EditPaymentTransactionHistoryRequest
            {
                Amount = Convert.ToDecimal("1337.17"),
                CustomerId = Guid.NewGuid().ToString(),
                Invoice = "b5b055349263448ca69e0bbd8b3eb90u",
                Tax = Convert.ToDecimal("337.17"),
                Transaction_Detail = "Payment Transaction History Test 2",
            };
            IPaymentTransactionHistoryService sut = new PaymentTransactionHistoryService(_paymentTransactionHistoryRepository, _paymentTransactionHistoryMapper);
            var result = await sut.EditPaymentTransactionHistoryAsync(testPaymentTransactionHistory);
            result.Amount.ShouldBe(testPaymentTransactionHistory.Amount);
            result.CustomerId.ShouldBe(testPaymentTransactionHistory.CustomerId);
            result.Invoice.ShouldBe(testPaymentTransactionHistory.Invoice);
            result.Tax.ShouldBe(testPaymentTransactionHistory.Tax);
            result.Transaction_Detail.ShouldBe(testPaymentTransactionHistory.Transaction_Detail);
        }
    }
}
