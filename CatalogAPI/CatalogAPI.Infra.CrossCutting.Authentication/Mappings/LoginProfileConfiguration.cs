using CatalogAPI.Domain.Application.Mappings;
using CatalogAPI.Domain.Model.ValueObjects.Account;
using CatalogAPI.Infra.CrossCutting.ViewModels;

namespace CatalogAPI.Infra.CrossCutting.Authentication.Mappings
{
    public class LoginProfileConfiguration : ProfileConfiguration
    {
        public LoginProfileConfiguration()
        {
            CreateMap<LoginRequest, ViewModelLoginRequest>().ReverseMap();
            CreateMap<RegisterRequest, ViewModelRegisterRequest>().ReverseMap();
        }
    }
}
