using System;
using System.Linq;
using System.Threading.Tasks;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace PaymentGateway.Fixtures
{
    public class SystemSettingRepositoryTests : IClassFixture<PaymentGatewayContextFactory>
    {
        private readonly SystemSettingRepository _sut;
        private readonly TestPaymentGatewayContext _paymentGatewayContext;
        public SystemSettingRepositoryTests(PaymentGatewayContextFactory paymentGatewayContextFactory)
        {
            _paymentGatewayContext = paymentGatewayContextFactory.ContextInstance;
            _sut = new SystemSettingRepository(_paymentGatewayContext);
        }
        [Fact]
        public async Task Should_Get_Data()
        {
            var result = await _sut.GetAsync();
            result.ShouldNotBeNull();
        }
        [Fact]
        public async Task Should_Returns_Null_With_CustomerId_Not_Present()
        {
            var result = await _sut.GetAsync(Guid.NewGuid().ToString());
            result.ShouldBeNull();
        }
        [Theory]
        [InlineData("b5b055349263448ca69e0bbd8b3eb90u")]
        public async Task Should_Return_Record_By_CustomerId(string guid)
        {
            var result = await _sut.GetAsync(guid);
            result.CustomerId.ShouldBe(guid);
        }
        [Fact]
        public async Task Should_Add_New_SystemSetting()
        {
            var testSystemSetting = new SystemSetting
            {
                AccountId = "8b0b8cf1eb402ew7a00",
                Active = true,
                ClientId = "MTQ5OTY2NjQ3Mg==",
                CustomerId = Guid.NewGuid().ToString(),
                Secret = "AgilisaTechnologies",
                PaymentGatewayUrl = "http://vmdataprueba.cloudapp.net/WebApi/APaymentTokenApi/",
                StoreUrl = "https://localhost:44358/payment/confirmation/",
            };
            _sut.Add(testSystemSetting);
            await _sut.UnitOfWork.SaveEntitiesAsync();
            _paymentGatewayContext.SystemSettings.FirstOrDefault(x => x.CustomerId == testSystemSetting.CustomerId).ShouldNotBeNull();
        }
        [Fact]
        public async Task Should_Update_SystemSetting()
        {
            var testSystemSetting = new SystemSetting
            {
                AccountId = "8b0b8cf1eb402ew7a00",
                Active = false,
                ClientId = "MTQ5OTY2NjQ3Mg==",
                CustomerId = "b5b055349263448ca69e0bbd8b3eb90u",
                Secret = "AgilisaTechnologies",
                PaymentGatewayUrl = "http://vmdataprueba.cloudapp.net/WebApi/APaymentTokenApi/",
                StoreUrl = "https://localhost:44358/payment/confirmation/",
            };
            _sut.Update(testSystemSetting);
            await _sut.UnitOfWork.SaveEntitiesAsync();
            _paymentGatewayContext.SystemSettings.FirstOrDefault(x => x.CustomerId == testSystemSetting.CustomerId)?.Active.ShouldBe(false);
        }
    }
}
