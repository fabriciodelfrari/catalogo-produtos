
namespace CatalogAPI.Domain.Interfaces.Token
{
    public interface ITokenService
    {
        string GenerateToken(string userId, string email);
    }
}
