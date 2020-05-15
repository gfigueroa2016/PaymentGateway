using PaymentGateway.Domain.Mappers;
using PaymentGateway.Domain.Repositories;
using PaymentGateway.Domain.Requests.PaymentTransactionHistory;
using PaymentGateway.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Domain.Services
{
    public class PaymentTransactionHistoryService : IPaymentTransactionHistoryService
    {
        private readonly IPaymentTransactionHistoryRepository _paymentTransactionHistoryRepository;
        private readonly IPaymentTransactionHistoryMapper _paymentTransactionHistoryMapper;

        public PaymentTransactionHistoryService(IPaymentTransactionHistoryRepository paymentTransactionHistoryRepository, IPaymentTransactionHistoryMapper paymentTransactionHistoryMapper)
        {
            _paymentTransactionHistoryRepository = paymentTransactionHistoryRepository;
            _paymentTransactionHistoryMapper = paymentTransactionHistoryMapper;
        }
        public async Task<PaymentTransactionHistoryResponse> AddPaymentTransactionHistoryAsync(AddPaymentTransactionHistoryRequest request)
        {
            var paymentTransactionHistory = _paymentTransactionHistoryMapper.Map(request);
            var result = _paymentTransactionHistoryRepository.Add(paymentTransactionHistory);
            await _paymentTransactionHistoryRepository.UnitOfWork.SaveChangesAsync();
            return _paymentTransactionHistoryMapper.Map(result);
        }
        public async Task<PaymentTransactionHistoryResponse> EditPaymentTransactionHistoryAsync(EditPaymentTransactionHistoryRequest request)
        {
            var existingRecord = await _paymentTransactionHistoryRepository.GetByInvoiceAsync(request.Invoice);
            if (existingRecord == null)
            {
                throw new ArgumentException($"Payment Transaction with invoice number: {request.Invoice}, is not present.");
            }
            var paymentTransactionHistory = _paymentTransactionHistoryMapper.Map(request);
            var result = _paymentTransactionHistoryRepository.Update(paymentTransactionHistory);
            await _paymentTransactionHistoryRepository.UnitOfWork.SaveChangesAsync();
            return _paymentTransactionHistoryMapper.Map(result);
        }
        public async Task<IEnumerable<PaymentTransactionHistoryResponse>> GetPaymentTransactionHistoryAsync()
        {
            var result = await _paymentTransactionHistoryRepository.GetAsync();
            return result.Select(p => _paymentTransactionHistoryMapper.Map(p));
        }
        public async Task<IEnumerable<PaymentTransactionHistoryResponse>> GetPaymentTransactionHistoryAsync(GetPaymentTransactionHistoryRequest request)
        {
            if (request?.CustomerId == null && request?.Invoice == null) throw new ArgumentNullException();
            var result = await _paymentTransactionHistoryRepository.GetByCustomerIdAsync(request.CustomerId);
            return result.Select(p => _paymentTransactionHistoryMapper.Map(p));
        }
        public async Task<IEnumerable<PaymentTransactionHistoryResponse>> GetPaymentTransactionHistoryHoldAsync()
        {
            var result = await _paymentTransactionHistoryRepository.GetPaymentTransactionHistoryHoldAsync();
            return result.Select(p => _paymentTransactionHistoryMapper.Map(p));
        }
        //public async Task<PaymentTransactionHistoryResponse> DeletePaymentTransactionHistoryAsync(DeleteSystemSettingRequest request)
        //{
        //    var paymentTransactionHistory = _paymentTransactionHistoryMapper.Map(request);
        //    var result = _paymentTransactionHistoryRepository.Delete(paymentTransactionHistory);
        //    await _paymentTransactionHistoryRepository.UnitOfWork.SaveChangesAsync();
        //    return _paymentTransactionHistoryMapper.Map(result);
        //}
    }
}
