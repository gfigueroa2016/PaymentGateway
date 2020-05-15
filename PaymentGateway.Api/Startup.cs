using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaymentGateway.Api.Swagger;
using Microsoft.OpenApi.Models;
using PaymentGateway.Api.Extensions;
using PaymentGateway.Domain.Repositories;
using PaymentGateway.Infrastructure.Repositories;
using PaymentGateway.Domain.Extensions;
using DynamicsPayments.Domain.Entities;
using DynamicsPayments.Extensions;

namespace PaymentGateway.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPaymentGatewayContext(Configuration.GetSection("ConnectionStrings:DefaultConnection").Value)
                .AddScoped<IPaymentTransactionHistoryRepository, PaymentTransactionHistoryRepository>()
                .AddScoped<ISystemSettingRepository, SystemSettingRepository>()
                .AddPaymentGatewayMappers()
                .AddPaymentGatewayServices()
                .AddControllers()
                .AddPaymentGatewayValidation();
            services.Configure<DynamicsPaymentsConfiguration>(Configuration.GetSection("DynamicsPaymentsSettings"));
            services.AddDynamicsPaymentsServices().AddControllers().AddDynamicsPaymentsValidation();
            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<PaymentGatewayContext>();
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Payment Gateway API", Version = "v1" });
            });
            services.AddCors(opt => 
            { 
                opt.AddPolicy("PaymentGatewayClientDomainPolicy", cfg => 
                { 
                    cfg.WithOrigins(Environment.IsDevelopment() ? Configuration.GetSection("PaymentGatewaySettings:DynamicsPaymentsDomainPolicyProduction").Value : Configuration.GetSection("PaymentGatewaySettings:DynamicsPaymentsDomainPolicyDevelopment").Value); 
                }); 
            });
        }
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
            app.UseSwagger(options => { options.RouteTemplate = swaggerOptions.JsonRoute; });
            app.UseSwaggerUI(options => { options.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description); });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default",
                "{Swagger}/{Index}/");
            });
        }
    }
}