using AutoMapper;
using login_infrastructure.Entities;
using login_service.DTOs;

namespace FixAppAPI.Service.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AccountDTO, Account>();

            CreateMap<Account, AuthenticateResponse>();          
        }
    }
}