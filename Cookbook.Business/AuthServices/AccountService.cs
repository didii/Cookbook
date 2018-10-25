using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Domain;
using Cookbook.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Cookbook.Business.AuthServices {
    internal class AccountService : IAccountService {
        private readonly UserManager<User> _userManager;
        private readonly IEmailSender _emailSender;

        public AccountService(UserManager<User> userManager, IEmailSender emailSender) {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        /// <inheritdoc />
        public async Task<UserDto> GetAsync(string userName) {
            var entity = await _userManager.FindByNameAsync(userName);
            return new UserDto() {
                UserName = entity.UserName,
                Email = entity.Email
            };
        }

        /// <inheritdoc />
        public async Task CreateAsync(UserCreate user) {
            var entity = new User() {UserName = user.UserName, Email = user.Email};
            var result = await _userManager.CreateAsync(entity, user.Password);
            if (!result.Succeeded)
                throw new Exception("Could not create user " + user.UserName);
        }
    }
}
