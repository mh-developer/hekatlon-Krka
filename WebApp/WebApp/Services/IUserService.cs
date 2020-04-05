using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();

        Task<UserDto> GetAsync(Guid userId);

        Task<UserDto> GetByEmailAsync(string email);

        Task<IdentityResult> CreateAsync(UserDto userDto);

        Task UpdateAsync(UserDto userDto);

        Task RemoveAsync(Guid userId);
    }
}