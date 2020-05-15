using DynamicsPayments.Domain.Models;
using DynamicsPayments.DTO.Transaction.Responses;
using System;

namespace DynamicsPayments.Domain.Mappers
{
    public class TransactionMapper : ITransactionMapper
    {
        public GetTransactionByIDResponse MapToGetTransactionByIDResponse(Transaction transaction)
        {
            if (transaction == null) return null;
            var getTransactionByIDResponse = new GetTransactionByIDResponse
            {
                Account = transaction.Account,
                AccountToken = transaction.AccountToken,
                AcquirerName = transaction.AcquirerName,
                AuditNumber = transaction.AuditNumber,
                AuthNumber = transaction.AuthNumber,
                BatchCode = transaction.Batch_Code,
                CardHolderName = transaction.CardHolderName,
                DesicionResponseCode = transaction.DesicionResponseCode,
                HostDate = Convert.ToDateTime(transaction.HostDate),
                HostTime = Convert.ToDateTime(transaction.HostTime).TimeOfDay,
                IDTransaction = transaction.IDTransaction,
                Message = transaction.Message,
                ResponseCode = transaction.ResponseCode,
                Status = transaction.Status
            };
            return getTransactionByIDResponse;
        }

        public MarkByIDResponse MapToMarkByIDResponse(Transaction transaction)
        {
            if (transaction == null) return null;
            var markByIDResponse = new MarkByIDResponse
            {
                Account = transaction.Account,
                AccountToken = transaction.AccountToken,
                AcquirerName = transaction.AcquirerName,
                AuditNumber = transaction.AuditNumber,
                AuthNumber = transaction.AuthNumber,
                BatchCode = transaction.Batch_Code,
                CardHolderName = transaction.CardHolderName,
                DesicionResponseCode = transaction.DesicionResponseCode,
                HostDate = Convert.ToDateTime(transaction.HostDate),
                HostTime = Convert.ToDateTime(transaction.HostTime).TimeOfDay,
                IDTransaction = transaction.IDTransaction,
                Message = transaction.Message,
                ResponseCode = transaction.ResponseCode,
                Status = transaction.Status
            };
            return markByIDResponse;
        }

        public VoidByIDResponse MapToVoidByIDResponse(Transaction transaction)
        {
            if (transaction == null) return null;
            var voidByIDResponse = new VoidByIDResponse
            {
                Account = transaction.Account,
                AccountToken = transaction.AccountToken,
                AcquirerName = transaction.AcquirerName,
                AuditNumber = transaction.AuditNumber,
                AuthNumber = transaction.AuthNumber,
                BatchCode = transaction.Batch_Code,
                CardHolderName = transaction.CardHolderName,
                DesicionResponseCode = transaction.DesicionResponseCode,
                HostDate = Convert.ToDateTime(transaction.HostDate),
                HostTime = Convert.ToDateTime(transaction.HostTime).TimeOfDay,
                IDTransaction = transaction.IDTransaction,
                Message = transaction.Message,
                ResponseCode = transaction.ResponseCode,
                Status = transaction.Status
            };
            return voidByIDResponse;
        }
    }
}