using DynamicsPayments.Client;
using DynamicsPayments.Domain.Services;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DynamicsPayments.Extensions
{
    public static class DynamicsPaymentsDependenciesRegistration
    {
        public static IServiceCollection AddDynamicsPaymentsServices(this IServiceCollection services)
        {
            services
                .AddSingleton<IDynamicsPaymentsConfigurationService, DynamicsPaymentsConfigurationService>()
                .AddScoped<IDynamicsPaymentsTokenService, DynamicsPaymentsTokenService>()
                .AddScoped<IDynamicsPaymentsTransactionService, DynamicsPaymentsTransactionService>()
                .AddHttpClient<IDynamicsPaymentsClient, DynamicsPaymentsClient>();
            return services;
        }
        public static IMvcBuilder AddDynamicsPaymentsValidation(this IMvcBuilder builder)
        {
            builder.AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
            return builder;
        }
    }
}