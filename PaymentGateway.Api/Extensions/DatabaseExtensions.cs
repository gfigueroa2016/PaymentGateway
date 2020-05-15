using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PaymentGateway.Infrastructure;

namespace PaymentGateway.Api.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddPaymentGatewayContext(this IServiceCollection services, string connectionString)
        {
            return services.AddEntityFrameworkSqlServer().AddDbContext<PaymentGatewayContext>((serviceProvider, contextOptions) =>
            {
                contextOptions.UseSqlServer(connectionString, serverOptions =>
                {
                    serverOptions.MigrationsAssembly(typeof(Startup).Assembly.FullName);
                }).UseInternalServiceProvider(serviceProvider);
            });
        }
    }
}
