using DynamicsPayments.Domain.Mappers;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Domain.Mappers;
using PaymentGateway.Infrastructure;
using System;

namespace PaymentGateway.Fixtures
{
    public class PaymentGatewayContextFactory
    {
        public readonly TestPaymentGatewayContext ContextInstance;
        public readonly IPaymentTransactionHistoryMapper PaymentTransactionHistoryMapper;
        public readonly ISystemSettingMapper SystemSettingMapper;
        public readonly ITokenMapper TokenMapper;
        public readonly ITransactionMapper TransactionMapper;
        public PaymentGatewayContextFactory()
        {
            var contextOptions = new DbContextOptionsBuilder<PaymentGatewayContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).EnableSensitiveDataLogging().Options;
            EnsureCreation(contextOptions);
            ContextInstance = new TestPaymentGatewayContext(contextOptions);
            PaymentTransactionHistoryMapper = new PaymentTransactionHistoryMapper();
            SystemSettingMapper = new SystemSettingMapper();
            TokenMapper = new TokenMapper();
            TransactionMapper = new TransactionMapper();
        }
        private void EnsureCreation(DbContextOptions<PaymentGatewayContext> contextOptions)
        {
            using var context = new TestPaymentGatewayContext(contextOptions);
            context.Database.EnsureCreated();
        }
    }
}
