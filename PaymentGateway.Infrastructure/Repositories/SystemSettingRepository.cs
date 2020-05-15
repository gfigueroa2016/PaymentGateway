using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentGateway.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Domain.Repositories;

namespace PaymentGateway.Infrastructure.Repositories
{
    public class SystemSettingRepository : ISystemSettingRepository
    {
        private readonly PaymentGatewayContext _paymentGatewayContext;
        public IUnitOfWork UnitOfWork => _paymentGatewayContext;

        public SystemSettingRepository(PaymentGatewayContext context)
        {
            _paymentGatewayContext = context ?? throw new ArgumentNullException(nameof(context));
        }
        public SystemSetting Add(SystemSetting systemSetting)
        {
            return _paymentGatewayContext.SystemSettings.Add(systemSetting).Entity;
        }
        public async Task<IEnumerable<SystemSetting>> GetAsync()
        {
            return await _paymentGatewayContext.SystemSettings.AsNoTracking().ToListAsync();
        }
        public async Task<SystemSetting> GetAsync(string customerId)
        {
            return await _paymentGatewayContext.SystemSettings.AsNoTracking().Where(x => x.CustomerId == customerId).FirstOrDefaultAsync();
        }
        public SystemSetting Update(SystemSetting systemSetting)
        {
            _paymentGatewayContext.Entry(systemSetting).State = EntityState.Modified;
            return systemSetting;
        }
    }
}