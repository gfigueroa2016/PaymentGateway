using Microsoft.EntityFrameworkCore;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Repositories;
using PaymentGateway.Infrastructure.SchemaDefinitions;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentGateway.Infrastructure
{
    public class PaymentGatewayContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "PaymentGateway";
        public DbSet<PaymentTransactionHistory> PaymentTransactionsHistory { get; set; }
        public DbSet<SystemSetting> SystemSettings { get; set; }
        public PaymentGatewayContext(DbContextOptions<PaymentGatewayContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaymentTransactionHistoryEntitySchemaDefinition());
            modelBuilder.ApplyConfiguration(new SystemSettingEntitySchemaDefinition());
            base.OnModelCreating(modelBuilder);
        }
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await SaveChangesAsync(cancellationToken) != 0 ? true : false;
        }
    }
}
