using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Infrastructure;
using PaymentGateway.Infrastructure.Repositories;
using Shouldly;
using Xunit;

namespace PaymentGateway.Fixtures
{
    public class SystemSettingRepositoryTests
    {
        [Fact]
        public async Task Should_Get_Data()
        {
            var options = new DbContextOptionsBuilder<PaymentGatewayContext>().UseInMemoryDatabase(databaseName: "Should_Get_Data").Options;
            using var context = new TestPaymentGatewayContext(options);
            context.Database.EnsureCreated();
            var sut = new SystemSettingRepository(context);
            var result = await sut.GetAsync();
            result.ShouldNotBeNull();
        }
        [Fact]
        public async Task Should_Returns_Null_With_CustomerId_Not_Present()
        {
            var options = new DbContextOptionsBuilder<PaymentGatewayContext>().UseInMemoryDatabase(databaseName: "Should_Returns_Null_With_CustomerId_Not_Present").Options;
            await using var context = new TestPaymentGatewayContext(options);
            context.Database.EnsureCreated();
            var sut = new SystemSettingRepository(context);
            var result = await sut.GetAsync(Guid.NewGuid().ToString());
            result.ShouldBeNull();
        }
        [Theory]
        [InlineData("b5b05534-9263-448c-a69e-0bbd8b3eb90u")]
        public async Task Should_Return_Record_By_CustomerId(string guid)
        {
            var options = new DbContextOptionsBuilder<PaymentGatewayContext>().UseInMemoryDatabase(databaseName: "Should_Return_Record_By_CustomerId").Options;
            await using var context = new TestPaymentGatewayContext(options);
            context.Database.EnsureCreated();
            var sut = new SystemSettingRepository(context);
            var result = await sut.GetAsync(new Guid(guid).ToString());
            result.CustomerId.ShouldBe(new Guid(guid).ToString());
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
            var options = new DbContextOptionsBuilder<PaymentGatewayContext>().UseInMemoryDatabase("Should_Add_New_SystemSetting").Options;
            await using var context = new TestPaymentGatewayContext(options);
            context.Database.EnsureCreated();
            var sut = new SystemSettingRepository(context);
            sut.Add(testSystemSetting);
            await sut.UnitOfWork.SaveEntitiesAsync();
            context.SystemSettings.FirstOrDefault(x => x.CustomerId == testSystemSetting.CustomerId).ShouldNotBeNull();
        }
        [Fact]
        public async Task Should_Update_SystemSetting()
        {
            var testSystemSetting = new SystemSetting
            {
                AccountId = "8b0b8cf1eb402ew7a00",
                Active = false,
                ClientId = "MTQ5OTY2NjQ3Mg==",
                CustomerId = new Guid("b5b05534-9263-448c-a69e-0bbd8b3eb90e").ToString(),
                Secret = "AgilisaTechnologies",
                PaymentGatewayUrl = "http://vmdataprueba.cloudapp.net/WebApi/APaymentTokenApi/",
                StoreUrl = "https://localhost:44358/payment/confirmation/",
            };
            var options = new DbContextOptionsBuilder<PaymentGatewayContext>().UseInMemoryDatabase("Should_Update_SystemSetting").Options;
            await using var context = new PaymentGatewayContext(options);
            context.Database.EnsureCreated();
            var sut = new SystemSettingRepository(context);
            sut.Update(testSystemSetting);
            await sut.UnitOfWork.SaveEntitiesAsync();
            context.SystemSettings.FirstOrDefault(x => x.CustomerId == testSystemSetting.CustomerId)?.Active.ShouldBe(false);
        }
    }
}
