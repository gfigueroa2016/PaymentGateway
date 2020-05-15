using DynamicsPayments.Domain.Models;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Fixtures.Extensions;
using PaymentGateway.Infrastructure;
using System;
using System.Collections.Generic;

namespace PaymentGateway.Fixtures
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
            modelBuilder.Seed<AuthorizeToken>($"C:/Users/Gabriel/Desktop/MultiSystems/PaymentGateway/PaymentGateway.Fixtures/Data/authorizetoken.json");
            modelBuilder.Seed<IEnumerable<GetCustomerTokens>>($"C:/Users/Gabriel/Desktop/MultiSystems/PaymentGateway/PaymentGateway.Fixtures/Data/getcustomertokens.json");
            modelBuilder.Seed<GetTransactionById>($"C:/Users/Gabriel/Desktop/MultiSystems/PaymentGateway/PaymentGateway.Fixtures/Data/gettransactionbyid.json");
            modelBuilder.Seed<MarkByID>($"C:/Users/Gabriel/Desktop/MultiSystems/PaymentGateway/PaymentGateway.Fixtures/Data/markbyid.json");
            modelBuilder.Seed<PaymentTransactionHistory>($"C:/Users/Gabriel/Desktop/MultiSystems/PaymentGateway/PaymentGateway.Fixtures/Data/paymenttransactionhistory.json");
            modelBuilder.Seed<RegisterToken>($"C:/Users/Gabriel/Desktop/MultiSystems/PaymentGateway/PaymentGateway.Fixtures/Data/registertoken.json");
            modelBuilder.Seed<SystemSetting>($"C:/Users/Gabriel/Desktop/MultiSystems/PaymentGateway/PaymentGateway.Fixtures/Data/systemsetting.json");
            modelBuilder.Seed<VoidByID>($"C:/Users/Gabriel/Desktop/MultiSystems/PaymentGateway/PaymentGateway.Fixtures/Data/voidbyid.json");
        }
    }
}