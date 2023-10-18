using Authentication.Models;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Data.Interfaces;

public interface IUserRepository
{
    Task<IdentityResult> RegisterAsync(AuthenticationIdentityUser user, string password, string role);
    Task<SignInResult> LoginAsync(AuthenticationIdentityUser user, string password);
    Task<AuthenticationIdentityUser> GetUserByEmailAsync(string email);
    Task<IList<string>> GetUserRolesAsync(AuthenticationIdentityUser user);
    Task<string> GenerateEmailConfirmationTokenAsync(AuthenticationIdentityUser user);
    Task<IdentityResult> ResetUserPasswordAsync(AuthenticationIdentityUser user, string resetToken, string newPassword);
    Task<IdentityResult> ChangeUserPasswordAsync(AuthenticationIdentityUser user, string currentPassword, string newPassword);
}
