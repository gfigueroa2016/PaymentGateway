using Microsoft.EntityFrameworkCore;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Infrastructure.Tests.Extensions;
using System.IO;

namespace PaymentGateway.Infrastructure.Tests
{
    public class TestPaymentGatewayContext : PaymentGatewayContext
    {
        public TestPaymentGatewayContext(DbContextOptions<PaymentGatewayContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed<SystemSetting>($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}/Data/systemsetting.json");
            modelBuilder.Seed<PaymentTransactionHistory>($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}/Data/paymenttransactionhistory.json");
        }
    }
}