using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentGateway.Domain.Entities;

namespace PaymentGateway.Infrastructure.SchemaDefinitions
{
    public class SystemSettingEntitySchemaDefinition : IEntityTypeConfiguration<SystemSetting>
    {
        public void Configure(EntityTypeBuilder<SystemSetting> builder)
        {
            builder.ToTable("SystemSettings", PaymentGatewayContext.DEFAULT_SCHEMA);
            builder.HasKey(k => new { k.CustomerId });
            builder.Property(p => p.AccountId).IsRequired();
            builder.Property(p => p.Active).IsRequired();
            builder.Property(p => p.ClientId).IsRequired();
            builder.Property(p => p.Created).ValueGeneratedOnAdd().HasDefaultValueSql("getdate()").IsRequired();
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.Modified).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("getdate()").IsRequired();
            builder.Property(p => p.PaymentGatewayUrl).IsRequired();
            builder.Property(p => p.RecordId).ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.Secret).IsRequired();
            builder.Property(p => p.StoreUrl).IsRequired();
        }
    }
}