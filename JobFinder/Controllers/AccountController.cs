using JobFinder.Entities.DTOs.AccountDTOs;
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
        public async Task<string> Register(RegisterDto userRegisterDto)
        {
            var result = await _accountService.Register(userRegisterDto);

            if (result is null)
                return "This Email Is Taken";

            return "Registered Succesfuly";
        }

        [HttpPost("Login")]
        public async Task<string> Login(LoginDto loginDto)
        {
            var result = await _accountService.Login(loginDto);

            if (result == null)
                return "Invalid Email Or Password";

            return result;
        }
    }
}
