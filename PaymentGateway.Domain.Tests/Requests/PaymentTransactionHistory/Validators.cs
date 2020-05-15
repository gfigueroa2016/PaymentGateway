using FluentValidation.TestHelper;
using PaymentGateway.Domain.Requests.PaymentTransactionHistory;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PaymentGateway.Domain.Tests.Requests.PaymentTransactionHistory
{
    public class Validators
    {
        public class AddPaymentTransactionHistoryRequestValidatorTests
        {
            private readonly AddPaymentTransactionHistoryRequestValidator _validator;
            public AddPaymentTransactionHistoryRequestValidatorTests()
            {
                _validator = new AddPaymentTransactionHistoryRequestValidator();
            }
            [Fact]
            public void Should_Have_Error_When_Invoice_Is_Null()
            {
                var addPaymentTransactionHistoryRequest = new AddPaymentTransactionHistoryRequest
                {
                    Invoice = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.Invoice, addPaymentTransactionHistoryRequest);
            }
            [Fact]
            public void Should_Have_Error_When_CustomerId_Is_Null()
            {
                var addPaymentTransactionHistoryRequest = new AddPaymentTransactionHistoryRequest
                {
                    CustomerId = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.CustomerId,
                addPaymentTransactionHistoryRequest);
            }
            [Fact]
            public void Should_Have_Error_When_Amount_Is_Equal_Or_Less_Than_Zero()
            {
                var addPaymentTransactionHistoryRequest = new AddPaymentTransactionHistoryRequest
                {
                    Amount = 0
                };
                _validator.ShouldHaveValidationErrorFor(x => x.Amount,
                addPaymentTransactionHistoryRequest);
            }
        }
    }
}