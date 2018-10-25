using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Dtos;

namespace Cookbook.Business.AuthServices {
    public interface IAccountService {
        Task<UserDto> GetAsync(string userName);
        Task CreateAsync(UserCreate user);
    }
}
