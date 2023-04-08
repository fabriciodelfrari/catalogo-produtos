using CatalogAPI.Domain.Interfaces.Authentication;
using CatalogAPI.Domain.Interfaces.Token;
using CatalogAPI.Domain.Model.ValueObjects.Account;
using CatalogAPI.Domain.Model.ValueObjects.Authentication;
using CatalogAPI.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity;


namespace CatalogAPI.Infra.CrossCutting.Authentication.Services
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthenticateService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<AuthenticationResult> Authenticate(LoginRequest loginRequest)
        {
            var authenticationResult = new AuthenticationResult();

            var user = await _userManager.FindByEmailAsync(loginRequest.Email);

            if (user == null)
            {
                authenticationResult.Succeeded = false;
                authenticationResult.ErrorMessage = "User not found.";

                return authenticationResult;
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginRequest.Password, false, false);

            if (result.Succeeded)
            {
                authenticationResult.Succeeded = result.Succeeded;
                authenticationResult.Token = _tokenService.GenerateToken(user.Id, user.Email!);
            }

            return authenticationResult;
        }

        public async Task<RegistrationResult> RegisterUser(RegisterRequest registerRequest)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = registerRequest.Email, //Pode-se colocar novas propriedades para o usuário futuramente
                Email = registerRequest.Email
            };

            var result = await _userManager.CreateAsync(applicationUser, registerRequest.Password);

            if (result.Succeeded)
                await _signInManager.SignInAsync(applicationUser, false);

            var registrationResult = new RegistrationResult();

            registrationResult.Succeeded = result.Succeeded;

            if (result.Errors.Any())
            {
                foreach (var error in result.Errors)
                {
                    registrationResult.Errors.Add(error.Description);
                }
            }

            return registrationResult;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
