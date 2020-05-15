using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Fixtures;
using PaymentGateway.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace PaymentGateway.Infrastructure.Tests
{
    public class PaymentTransactionHistoryRepositoryTests : IClassFixture<PaymentGatewayContextFactory>
    {
        [Fact]
        public async Task Should_Get_Data()
        {
            var options = new DbContextOptionsBuilder<PaymentGatewayContext>().UseInMemoryDatabase(databaseName: "Should_Get_Data").Options;
            using var context = new TestPaymentGatewayContext(options);
            context.Database.EnsureCreated();
            var sut = new PaymentTransactionHistoryRepository(context);
            var result = await sut.GetAsync();
            result.ShouldNotBeNull();
        }
        [Fact]
        public async Task Should_Returns_Null_With_Invoice_Not_Present()
        {
            var options = new DbContextOptionsBuilder<PaymentGatewayContext>().UseInMemoryDatabase(databaseName: "Should_Returns_Null_With_Invoice_Not_Present").Options;
            await using var context = new TestPaymentGatewayContext(options);
            context.Database.EnsureCreated();
            var sut = new PaymentTransactionHistoryRepository(context);
            var result = await sut.GetByInvoiceAsync(Guid.NewGuid().ToString());
            result.ShouldBeNull();
        }
        [Theory]
        [InlineData("b5b05534-9263-448c-a69e-0bbd8b3eb90u")]
        public async Task Should_Return_Record_By_Invoice(string guid)
        {
            var options = new DbContextOptionsBuilder<PaymentGatewayContext>()
            .UseInMemoryDatabase(databaseName: "Should_Return_Record_By_Invoice").Options;
            await using var context = new TestPaymentGatewayContext(options);
            context.Database.EnsureCreated();
            var sut = new PaymentTransactionHistoryRepository(context);
            var result = await sut.GetByInvoiceAsync(new Guid(guid).ToString());
            result.Invoice.ShouldBe(new Guid(guid).ToString());
        }
        [Fact]
        public async Task Should_Add_New_PaymentTransactionHistory()
        {
            var testPaymentTransactionHistory = new PaymentTransactionHistory
            {
                Amount = Convert.ToDecimal("1337.17"),
                CustomerId = new Guid("b5b05534-9263-448c-a69e-0bbd8b3eb90e").ToString(),
                Invoice = new Guid().ToString(),
                Tax = Convert.ToDecimal("337.17"),
                Transaction_Detail = "Payment Transaction Test",
            };
            var options = new DbContextOptionsBuilder<PaymentGatewayContext>()
            .UseInMemoryDatabase("Should_Add_New_PaymentTransactionHistory")
            .Options;
            await using var context = new TestPaymentGatewayContext(options);
            context.Database.EnsureCreated();
            var sut = new PaymentTransactionHistoryRepository(context);
            sut.Add(testPaymentTransactionHistory);
            await sut.UnitOfWork.SaveEntitiesAsync();
            context.PaymentTransactionsHistory.FirstOrDefault(x => x.Invoice == testPaymentTransactionHistory.Invoice).ShouldNotBeNull();
        }
        [Fact]
        public async Task Should_Update_PaymentTransactionHistory()
        {
            var testPaymentTransactionHistory = new PaymentTransactionHistory
            {
                Amount = Convert.ToDecimal("1337.17"),
                CustomerId = new Guid("b5b05534-9263-448c-a69e-0bbd8b3eb90e").ToString(),
                Invoice = new Guid("b5b05534-9263-448c-a69e-0bbd8b3eb90e").ToString(),
                Tax = Convert.ToDecimal("337.17"),
                Transaction_Detail = "Payment Transaction Test 2",
            };
            var options = new DbContextOptionsBuilder<PaymentGatewayContext>().UseInMemoryDatabase("Should_Update_PaymentTransactionHistory").Options;
            await using var context = new PaymentGatewayContext(options);
            context.Database.EnsureCreated();
            var sut = new PaymentTransactionHistoryRepository(context);
            sut.Update(testPaymentTransactionHistory);
            await sut.UnitOfWork.SaveEntitiesAsync();
            context.PaymentTransactionsHistory.FirstOrDefault(x => x.CustomerId == testPaymentTransactionHistory.CustomerId)?.Transaction_Detail.ShouldBe("Payment Transaction Test 2");
        }
    }
}
