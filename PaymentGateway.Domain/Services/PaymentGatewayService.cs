using PaymentGateway.Domain.Reponses;
using PaymentGateway.Domain.Requests.PaymentTransactionHistory;
using PaymentGateway.Domain.Requests.SystemSetting;
using PaymentGateway.Domain.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentGateway.Domain.Services
{
    public interface IPaymentTransactionHistoryService
    {
        Task<PaymentTransactionHistoryResponse> AddPaymentTransactionHistoryAsync(AddPaymentTransactionHistoryRequest request);
        Task<PaymentTransactionHistoryResponse> EditPaymentTransactionHistoryAsync(EditPaymentTransactionHistoryRequest request);
        Task<IEnumerable<PaymentTransactionHistoryResponse>> GetPaymentTransactionHistoryAsync();
        Task<IEnumerable<PaymentTransactionHistoryResponse>> GetPaymentTransactionHistoryAsync(GetPaymentTransactionHistoryRequest request);
        Task<IEnumerable<PaymentTransactionHistoryResponse>> GetPaymentTransactionHistoryHoldAsync();
        //Task<PaymentTransactionHistoryResponse> DeletePaymentTransactionsHistoryAsync(DeleteSystemSettingRequest request);
    }
    public interface ISystemSettingService
    {
        Task<SystemSettingResponse> AddSystemSettingAsync(AddSystemSettingRequest request);
        Task<SystemSettingResponse> EditSystemSettingAsync(EditSystemSettingRequest request);
        Task<IEnumerable<SystemSettingResponse>> GetSystemSettingsAsync();
        Task<SystemSettingResponse> GetSystemSettingAsync(GetSystemSettingRequest request);
        //Task<SystemSettingResponse> DeleteSystemSettingByCustomerIdAsync(DeleteSystemSettingRequest request);
    }
}
