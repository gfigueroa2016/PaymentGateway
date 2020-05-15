using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PaymentGateway.Domain.Entities;
using System.Threading;

namespace PaymentGateway.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
    public interface IPaymentTransactionHistoryRepository : IRepository
    {
        PaymentTransactionHistory Add(PaymentTransactionHistory paymentTransactionHistory);
        Task<IEnumerable<PaymentTransactionHistory>> GetAsync();
        Task<IEnumerable<PaymentTransactionHistory>> GetByCustomerIdAsync(string customerId);
        Task<PaymentTransactionHistory> GetByInvoiceAsync(string invoice);
        Task<IEnumerable<PaymentTransactionHistory>> GetPaymentTransactionHistoryHoldAsync();
        PaymentTransactionHistory Update(PaymentTransactionHistory paymentTransactionHistory);
    }
    public interface ISystemSettingRepository : IRepository
    {
        SystemSetting Add(SystemSetting systemSetting);
        Task<IEnumerable<SystemSetting>> GetAsync();
        Task<SystemSetting> GetAsync(string customerId);
        SystemSetting Update(SystemSetting systemSetting);
    }
}
