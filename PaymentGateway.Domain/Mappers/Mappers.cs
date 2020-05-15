using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Reponses;
using PaymentGateway.Domain.Requests.PaymentTransactionHistory;
using PaymentGateway.Domain.Requests.SystemSetting;
using PaymentGateway.Domain.Responses;

namespace PaymentGateway.Domain.Mappers
{
    public interface IPaymentTransactionHistoryMapper
    {
        PaymentTransactionHistory Map(AddPaymentTransactionHistoryRequest request);
        PaymentTransactionHistory Map(EditPaymentTransactionHistoryRequest request);
        PaymentTransactionHistoryResponse Map(PaymentTransactionHistory paymentTransactionHistory);
    }
    public interface ISystemSettingMapper
    {
        SystemSetting Map(AddSystemSettingRequest request);
        SystemSetting Map(EditSystemSettingRequest request);
        SystemSettingResponse Map(SystemSetting systemSetting);
    }
}
