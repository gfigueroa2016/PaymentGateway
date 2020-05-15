using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentGateway.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Domain.Repositories;
using System.Net.WebSockets;

namespace PaymentGateway.Domain.Repositories
{

    public class PaymentTransactionHistoryRepository : IPaymentTransactionHistoryRepository
    {
        private readonly PaymentGatewayContext _paymentGatewayContext;
        public IUnitOfWork UnitOfWork => _paymentGatewayContext;

        public PaymentTransactionHistoryRepository(PaymentGatewayContext context)
        {
            _paymentGatewayContext = context ?? throw new ArgumentNullException(nameof(context));
        }
        public PaymentTransactionHistory Add(PaymentTransactionHistory paymentTransactionHistory)
        {
            return _paymentGatewayContext.PaymentTransactionsHistory.Add(paymentTransactionHistory).Entity;
        }
        public async Task<IEnumerable<PaymentTransactionHistory>> GetAsync()
        {
            return await _paymentGatewayContext.PaymentTransactionsHistory.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<PaymentTransactionHistory>> GetByCustomerIdAsync(string customerId)
        {
            return await _paymentGatewayContext.PaymentTransactionsHistory.Where(p => p.CustomerId == customerId).AsNoTracking().ToListAsync();
        }
        public async Task<PaymentTransactionHistory> GetByInvoiceAsync(string invoice)
        {
            return await _paymentGatewayContext.PaymentTransactionsHistory.Where(p => p.Invoice == invoice).AsNoTracking().FirstOrDefaultAsync();
        }
        public PaymentTransactionHistory Update(PaymentTransactionHistory paymentTransactionHistory)
        {
            _paymentGatewayContext.Entry(paymentTransactionHistory).State = EntityState.Modified;
            return paymentTransactionHistory;
        }
        //public PaymentTransactionHistory Delete(PaymentTransactionHistory paymentTransactionHistory)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
