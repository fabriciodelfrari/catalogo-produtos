using CatalogAPI.Domain.Model.ValueObjects.Account;
using CatalogAPI.Domain.Model.ValueObjects.Authentication;

namespace CatalogAPI.Domain.Interfaces.Authentication
{
    public interface IAuthenticate
    {
        Task<AuthenticationResult> Authenticate(LoginRequest loginRequest);
        Task<RegistrationResult> RegisterUser(RegisterRequest registerRequest);
        Task Logout();
    }
}
