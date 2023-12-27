using JobFinder.Entities.DTOs;
using JobFinder.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<bool> Register([FromBody] RegisterationDto userRegisterDto)
        {

            var result = await _accountService.Register(userRegisterDto);

            if (result is null)
                throw new Exception("Error");

            return true;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<string> Login([FromBody] LoginDto loginDto)
        {

            var result = await _accountService.Login(loginDto);

            if (result == null)
            {
                throw new Exception("Error");
            }
            return result;

        }
    }
}
