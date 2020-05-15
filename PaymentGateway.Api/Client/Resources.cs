using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Api.Client
{
    public interface ICatalogItemResource
    {
        Task<ItemResponse> Get(Guid id, CancellationToken
        cancellationToken = default);
    }
}
