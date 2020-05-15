using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Requests.PaymentTransactionHistory;
using PaymentGateway.Domain.Responses;

namespace PaymentGateway.Domain.Mappers
{
    public class PaymentTransactionHistoryMapper : IPaymentTransactionHistoryMapper
    {
        public PaymentTransactionHistory Map(AddPaymentTransactionHistoryRequest addPaymentTransactionHistoryRequest)
        {
            if (addPaymentTransactionHistoryRequest == null) return null;
            var paymentTransactionHistory = new PaymentTransactionHistory
            {
                Amount = addPaymentTransactionHistoryRequest.Amount,
                CustomerId = addPaymentTransactionHistoryRequest.CustomerId,
                Invoice = addPaymentTransactionHistoryRequest.Invoice,
                Tax = addPaymentTransactionHistoryRequest.Tax,
                Transaction_Detail = addPaymentTransactionHistoryRequest.Transaction_Detail
            };
            return paymentTransactionHistory;
        }

        public PaymentTransactionHistory Map(EditPaymentTransactionHistoryRequest editPaymentTransactionHistoryRequest)
        {
            if (editPaymentTransactionHistoryRequest == null) return null; 
            var paymentTransactionHistory = new PaymentTransactionHistory
            {
                Amount = editPaymentTransactionHistoryRequest.Amount,
                CustomerId = editPaymentTransactionHistoryRequest.CustomerId,
                Invoice = editPaymentTransactionHistoryRequest.Invoice,
                Tax = editPaymentTransactionHistoryRequest.Tax,
                Transaction_Detail = editPaymentTransactionHistoryRequest.Transaction_Detail
            };
            return paymentTransactionHistory;
        }

        public PaymentTransactionHistoryResponse Map(PaymentTransactionHistory paymentTransactionHistory)
        {
            if (paymentTransactionHistory == null) return null;
            var paymentTransactionHistoryResponse = new PaymentTransactionHistoryResponse
            {
                Amount = paymentTransactionHistory.Amount,
                Created = paymentTransactionHistory.Created,
                CustomerId = paymentTransactionHistory.CustomerId,
                Invoice = paymentTransactionHistory.Invoice,
                Modified = paymentTransactionHistory.Modified,
                ReserveFunds = paymentTransactionHistory.ReserveFunds,
                Tax = paymentTransactionHistory.Tax,
                Transaction_Detail = paymentTransactionHistory.Transaction_Detail
            };
            return paymentTransactionHistoryResponse;
        }
    }
}
