using Microsoft.AspNetCore.Mvc.Routing;
using System;

namespace DynamicsPayments.Domain.Routes
{
    public class TokenRoute : Attribute, IRouteTemplateProvider
    {
        public string Template => "payment/api";

        public int? Order { get; set; }
        public string Name => "Token_route";
    }
}
