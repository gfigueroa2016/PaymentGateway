using DynamicsPayments.Domain.Models;
using DynamicsPayments.DTO.Requests;
using DynamicsPayments.DTO.Responses;
using DynamicsPayments.DTO.Transaction.Requests;
using DynamicsPayments.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicsPayments.Domain.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public Task<Transaction> GetTransactionByIDAsync(GetTransactionByIDRequest getTransactionByIDRequest)
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> MarkByIDAsync(MarkByIDRequest markByIDRequest)
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> RegisterTokenAsync(VoidByIDRequest voidByIDRequest)
        {
            throw new NotImplementedException();
        }
    }
}
