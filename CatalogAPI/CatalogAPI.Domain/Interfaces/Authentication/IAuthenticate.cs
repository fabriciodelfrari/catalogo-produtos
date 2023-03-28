
namespace CatalogAPI.Domain.Interfaces.Authentication
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> RegisterUser(string email, string password);
        Task Logout();
    }
}
