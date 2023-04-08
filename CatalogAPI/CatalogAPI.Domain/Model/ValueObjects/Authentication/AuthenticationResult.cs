namespace CatalogAPI.Domain.Model.ValueObjects.Authentication
{
    public class AuthenticationResult
    {
        public bool Succeeded { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
    }
}
