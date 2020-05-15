using AutoMapper;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Reponses;
using PaymentGateway.Domain.Responses;

namespace PaymentGateway.Domain.Mappers
{
    public class PaymentGatewayProfile : Profile
    {
        public PaymentGatewayProfile()
        {
            CreateMap<PaymentTransactionHistoryResponse, PaymentTransactionHistory>().ReverseMap();
            CreateMap<SystemSettingResponse, SystemSetting>().ReverseMap();
        }
    }
}
