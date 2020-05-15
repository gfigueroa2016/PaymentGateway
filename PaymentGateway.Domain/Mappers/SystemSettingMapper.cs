using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Reponses;
using PaymentGateway.Domain.Requests.SystemSetting;

namespace PaymentGateway.Domain.Mappers
{
    public class SystemSettingMapper : ISystemSettingMapper
    {
        public SystemSetting Map(AddSystemSettingRequest addSystemSettingRequest)
        {
            if (addSystemSettingRequest == null) return null;
            var systemSetting = new SystemSetting
            {
                AccountId = addSystemSettingRequest.AccountId,
                Active = addSystemSettingRequest.Active,
                ClientId = addSystemSettingRequest.ClientId,
                CustomerId = addSystemSettingRequest.CustomerId,
                PaymentGatewayUrl = addSystemSettingRequest.PaymentGatewayUrl,
                Secret = addSystemSettingRequest.Secret,
                StoreUrl = addSystemSettingRequest.StoreUrl
            };
            return systemSetting;
        }

        public SystemSetting Map(EditSystemSettingRequest editSystemSettingRequest)
        {
            if (editSystemSettingRequest == null) return null;
            var systemSetting = new SystemSetting
            {
                AccountId = editSystemSettingRequest.AccountId,
                Active = editSystemSettingRequest.Active,
                ClientId = editSystemSettingRequest.ClientId,
                CustomerId = editSystemSettingRequest.CustomerId,
                PaymentGatewayUrl = editSystemSettingRequest.PaymentGatewayUrl,
                Secret = editSystemSettingRequest.Secret,
                StoreUrl = editSystemSettingRequest.StoreUrl
            };
            return systemSetting;
        }

        public SystemSettingResponse Map(SystemSetting systemSetting)
        {
            if (systemSetting == null) return null;
            var systemSettingResponse = new SystemSettingResponse
            {
                AccountId = systemSetting.AccountId,
                Active = systemSetting.Active,
                ClientId = systemSetting.ClientId,
                Created = systemSetting.Created,
                CustomerId = systemSetting.CustomerId,
                Modified = systemSetting.Modified,
                PaymentGatewayUrl = systemSetting.PaymentGatewayUrl,
                Secret = systemSetting.Secret,
                StoreUrl = systemSetting.StoreUrl
            };
            return systemSettingResponse;
        }
    }
}