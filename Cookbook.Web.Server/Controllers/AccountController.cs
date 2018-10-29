using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Business.AuthServices;
using Cookbook.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Cookbook.Web.Server.Controllers {
    [Route("account")]
    [ApiController]
    public class AccountController : Controller {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService) {
            _accountService = accountService;
        }

        [HttpGet("find/byname/{userName}")]
        public async Task<UserDto> GetByName(string userName) {
            var result = await _accountService.GetAsync(userName);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreate user) {
            await _accountService.CreateAsync(user);
            return NoContent();
        }


    }
}
