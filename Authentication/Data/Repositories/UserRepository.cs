using Authentication.Data.Interfaces;
using Authentication.Models;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<AuthenticationIdentityUser> _userManager;
    private readonly SignInManager<AuthenticationIdentityUser> _signInManager;

    public UserRepository(UserManager<AuthenticationIdentityUser> userManager, SignInManager<AuthenticationIdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IdentityResult> RegisterAsync(AuthenticationIdentityUser user, string password, string role)
    {
        try
        {
            IdentityResult responseCreateUser = await _userManager.CreateAsync(user, password);

            if (responseCreateUser.Succeeded)
            {
                return await _userManager.AddToRoleAsync(user, role);
            }

            return responseCreateUser;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<SignInResult> LoginAsync(AuthenticationIdentityUser user, string password)
    {
        return await _signInManager.PasswordSignInAsync(user.UserName!, password, false, false);
    }

    public async Task<AuthenticationIdentityUser> GetUserByEmailAsync(string email)
    {
        try
        {
            AuthenticationIdentityUser user = await _userManager.FindByEmailAsync(email);

            return user;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IList<string>> GetUserRolesAsync(AuthenticationIdentityUser user)
    {
        try
        {
            return await _userManager.GetRolesAsync(user);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<string> GenerateEmailConfirmationTokenAsync(AuthenticationIdentityUser user)
    {
        try
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IdentityResult> ResetUserPasswordAsync(AuthenticationIdentityUser user, string resetToken, string newPassword)
    {
        try
        {
            return await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IdentityResult> ChangeUserPasswordAsync(AuthenticationIdentityUser user, string currentPassword, string newPassword)
    {
        try
        {
            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
