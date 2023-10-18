using Authentication.Models;
using Authentication.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Services.Interfaces;

public interface IUserService
{
    Task<AuthenticationIdentityUser> Register(CreateUserDTO model);
    Task<string> Login(LoginUserDTO model);
    Task<string> ForgotPassword(string email);
    Task<IdentityResult> ResetUserPassword(ResetUserPasswordDTO model);
    Task ChangeUserPassword(ChangeUserPasswordDTO model);
    Task<AuthenticationIdentityUser> GetUserByEmailAsync(string email);
}
