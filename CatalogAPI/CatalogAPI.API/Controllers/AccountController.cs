using AutoMapper;
using CatalogAPI.Domain.Interfaces.Authentication;
using CatalogAPI.Domain.Model.ValueObjects.Account;
using CatalogAPI.Domain.Model.ValueObjects.Authentication;
using CatalogAPI.Infra.CrossCutting.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticate _authenticationService;
        private readonly IMapper _mapper;

        public AccountController(IAuthenticate authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthenticationResult>> Login([FromBody] ViewModelLoginRequest viewModelLoginRequest)
        {
            try
            {
                var loginRequest = _mapper.Map<LoginRequest>(viewModelLoginRequest);

                var result = await _authenticationService.Authenticate(loginRequest);

                if (!result.Succeeded)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegistrationResult>> Register(ViewModelRegisterRequest viewModelRegisterRequest)
        {
            try
            {
                var registerRequest = _mapper.Map<RegisterRequest>(viewModelRegisterRequest);

                var result = await _authenticationService.RegisterUser(registerRequest);

                if (!result.Succeeded)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message} - {ex.StackTrace}");
            }
        }
    }
}
