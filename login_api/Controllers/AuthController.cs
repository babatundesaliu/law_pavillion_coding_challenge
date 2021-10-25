using login_service.DTOs;
using login_service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace login_api.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(
      IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticateResponse>> Login(AuthenticateRequest model)
        {
            var response = await _authService.Authenticate(model);
           
            if (String.IsNullOrEmpty(response.JwtToken))
            {
                return Unauthorized();
            }
            else
            {
                return Ok(response);
            }
        }
    }
}
