using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentGateway.Domain.Entities;

namespace PaymentGateway.Infrastructure.SchemaDefinitions
{
    public class PaymentTransactionHistoryEntitySchemaDefinition : IEntityTypeConfiguration<PaymentTransactionHistory>
    {
        public void Configure(EntityTypeBuilder<PaymentTransactionHistory> builder)
        {
            builder.ToTable("PaymentTransactionsHistory", PaymentGatewayContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.Invoice);
            builder.Property(p => p.Amount).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(p => p.Created).ValueGeneratedOnAdd().HasDefaultValueSql("getdate()").IsRequired();
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.Invoice).IsRequired();
            builder.Property(p => p.Modified).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("getdate()").IsRequired();
            builder.Property(p => p.RecordId).ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.Tax).HasColumnType("decimal(18, 2)");
            builder.Property(p => p.Transaction_Detail);
            builder.Property(p => p.ReserveFunds).ValueGeneratedOnAddOrUpdate().HasDefaultValue(false).IsRequired();
        }
    }
}