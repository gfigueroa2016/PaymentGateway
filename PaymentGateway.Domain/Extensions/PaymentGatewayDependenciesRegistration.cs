using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using PaymentGateway.Domain.Mappers;
using PaymentGateway.Domain.Services;
using System.Reflection;

namespace PaymentGateway.Domain.Extensions
{
    public static class PaymentGatewayDependenciesRegistration
    {
        public static IServiceCollection AddPaymentGatewayMappers(this IServiceCollection services)
        {
            services
                .AddSingleton<IPaymentTransactionHistoryMapper, PaymentTransactionHistoryMapper>()
                .AddSingleton<ISystemSettingMapper, SystemSettingMapper>();
            return services;
        }
        public static IServiceCollection AddPaymentGatewayServices(this
        IServiceCollection services)
        {
            services
                .AddScoped<IPaymentTransactionHistoryService, PaymentTransactionHistoryService>()
                .AddScoped<ISystemSettingService, SystemSettingService>();
            return services;
        }
        public static IMvcBuilder AddPaymentGatewayValidation(this IMvcBuilder builder)
        {
            builder.AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
            return builder;
        }
    }
}