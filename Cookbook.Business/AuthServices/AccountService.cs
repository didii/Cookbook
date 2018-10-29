using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Domain;
using Cookbook.Dtos;
using Cookbook.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Cookbook.Business.AuthServices {
    internal class AccountService : IAccountService {
        private readonly UserManager<IdentityUser> _userManager;

        public AccountService(UserManager<IdentityUser> userManager) {
            _userManager = userManager;
        }

        /// <inheritdoc />
        public async Task<UserDto> GetAsync(string userName) {
            var entity = await _userManager.FindByNameAsync(userName);
            if (entity == null) {
                throw new NotFoundException(typeof(IdentityUser), userName);
            }
            return new UserDto() {
                UserName = entity.UserName,
                Email = entity.Email
            };
        }

        /// <inheritdoc />
        public async Task CreateAsync(UserCreate user) {
            var entity = new IdentityUser() {UserName = user.UserName, Email = user.Email};
            var result = await _userManager.CreateAsync(entity, user.Password);
            if (!result.Succeeded)
                throw new AccountCreateException(user.UserName, result.Errors);
        }
    }
}
