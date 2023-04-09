namespace CatalogAPI.Domain.Model.ValueObjects.Account
{
    public class RegisterRequest
    {
        //classe para facilitar adicionar propriedades para registro de usuário
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
