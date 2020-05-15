using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentGateway.Api.Client
{
        public interface IBaseClient
        {
            Task<T> GetAsync<T>(Uri uri, CancellationToken cancellationToken);
            Uri BuildUri(string format);
        }
}
