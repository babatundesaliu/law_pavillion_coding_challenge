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
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(
       IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthenticateResponse>> Register(AccountDTO model)
        {
            try
            {
                await _accountService.Register(model);
                return Ok("Registered Successfully");
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }                       
        }
    }
}
