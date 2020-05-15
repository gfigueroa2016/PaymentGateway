using PaymentGateway.Domain.Mappers;
using PaymentGateway.Domain.Repositories;
using PaymentGateway.Domain.Requests.SystemSetting;
using PaymentGateway.Domain.Services;
using PaymentGateway.Fixtures;
using PaymentGateway.Infrastructure.Repositories;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PaymentGateway.Domain.Tests.Services
{
    public class SystemSettingServiceTests : IClassFixture<PaymentGatewayContextFactory>
    {
        private readonly ISystemSettingRepository _systemSettingRepository;
        private readonly ISystemSettingMapper _systemSettingMapper;
        public SystemSettingServiceTests(PaymentGatewayContextFactory paymentGatewayContextFactory)
        {
            _systemSettingRepository = new SystemSettingRepository(paymentGatewayContextFactory.ContextInstance);
            _systemSettingMapper = paymentGatewayContextFactory.SystemSettingMapper;
        }
        [Fact]
        public async Task GetSystemSettings_Should_Return_Right_Data()
        {
            ISystemSettingService sut = new SystemSettingService(_systemSettingRepository, _systemSettingMapper);
            var result = await sut.GetSystemSettingsAsync();
            result.ShouldNotBeNull();
        }
        [Theory]
        [InlineData("b5b055349263448ca69e0bbd8b3eb90u")]
        public async Task GetSystemSetting_Should_Return_Right_Data(string guid)
        {
            ISystemSettingService sut = new SystemSettingService(_systemSettingRepository, _systemSettingMapper);
            var result = await sut.GetSystemSettingAsync(new GetSystemSettingRequest { CustomerId = guid });
            result.CustomerId.ShouldBe(guid);
        }
        [Fact]
        public void GetSystemSetting_Should_Thrown_Exception_With_Null_Id()
        {
            ISystemSettingService sut = new SystemSettingService(_systemSettingRepository, _systemSettingMapper);
            sut.GetSystemSettingAsync(new GetSystemSettingRequest { CustomerId = null }).ShouldThrow<ArgumentNullException>();
        }
        [Fact]
        public async Task AddSystemSetting_Should_Add_Right_Entity()
        {
            var testSystemSetting = new AddSystemSettingRequest
            {
                AccountId = "12345",
                Active = true,
                ClientId = "1234",
                CustomerId = "123456",
                PaymentGatewayUrl = "http://vmdataprueba.cloudapp.net/WebApi/APaymentTokenApi/",
                Secret = "AgilisaTechnologies",
                StoreUrl = "https://localhost:44358/payment/confirmation/"
            };
            ISystemSettingService sut = new SystemSettingService(_systemSettingRepository, _systemSettingMapper);
            var result = await sut.AddSystemSettingAsync(testSystemSetting);
            result.AccountId.ShouldBe(testSystemSetting.AccountId);
            result.Active.ShouldBe(testSystemSetting.Active);
            result.ClientId.ShouldBe(testSystemSetting.ClientId);
            result.CustomerId.ShouldBe(testSystemSetting.CustomerId);
            result.PaymentGatewayUrl.ShouldBe(testSystemSetting.PaymentGatewayUrl);
            result.Secret.ShouldBe(testSystemSetting.Secret);
            result.StoreUrl.ShouldBe(testSystemSetting.StoreUrl);
        }
        [Fact]
        public async Task EditSystemSetting_Should_Add_Right_Entity()
        {
            var testSystemSetting = new EditSystemSettingRequest
            {
                AccountId = Guid.NewGuid().ToString(),
                Active = false,
                ClientId = Guid.NewGuid().ToString(),
                CustomerId = "b5b055349263448ca69e0bbd8b3eb90u",
                PaymentGatewayUrl = "http://vmdataprueba.cloudapp.net/WebApi/APaymentTokenApi/",
                Secret = "AgilisaTechnologies",
                StoreUrl = "https://localhost:44358/payment/confirmation/"
            };
            ISystemSettingService sut = new SystemSettingService(_systemSettingRepository, _systemSettingMapper);
            var result = await sut.EditSystemSettingAsync(testSystemSetting);
            result.AccountId.ShouldBe(testSystemSetting.AccountId);
            result.Active.ShouldBe(testSystemSetting.Active);
            result.ClientId.ShouldBe(testSystemSetting.ClientId);
            result.CustomerId.ShouldBe(testSystemSetting.CustomerId);
            result.PaymentGatewayUrl.ShouldBe(testSystemSetting.PaymentGatewayUrl);
            result.Secret.ShouldBe(testSystemSetting.Secret);
            result.StoreUrl.ShouldBe(testSystemSetting.StoreUrl);
        }
    }
}
