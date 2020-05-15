using AutoMapper;
using DynamicsPayments.Domain.DTO.Token.Requests;
using DynamicsPayments.Domain.DTO.Token.Responses;

namespace DynamicsPayments.Domain.Mappers
{
    public class DynamicsPaymentsProfile : Profile
    {
        public DynamicsPaymentsProfile()
        {
            CreateMap<AuthorizeTokenRequest, AuthorizeTokenRequest>().ReverseMap();
        }
    }
}