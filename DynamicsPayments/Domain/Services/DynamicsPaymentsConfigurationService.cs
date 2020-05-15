using DynamicsPayments.Domain.Entities;
using Microsoft.Extensions.Options;

namespace DynamicsPayments.Domain.Services
{
    public class DynamicsPaymentsConfigurationService : IDynamicsPaymentsConfigurationService
    {
        private DynamicsPaymentsConfiguration _dynamicsPaymentsConfigurationService;

        public DynamicsPaymentsConfigurationService(IOptionsMonitor<DynamicsPaymentsConfiguration> optionsMonitor)
        {
            _dynamicsPaymentsConfigurationService = optionsMonitor.CurrentValue;
            optionsMonitor.OnChange(dynamicsPaymentConfigurationService => { _dynamicsPaymentsConfigurationService = dynamicsPaymentConfigurationService; });
        }
        public DynamicsPaymentsConfiguration GetDynamicsPaymentsConfiguration()
        {
            return _dynamicsPaymentsConfigurationService;
        }
    }
}