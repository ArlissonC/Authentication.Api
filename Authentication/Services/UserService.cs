using Authentication.Data.Interfaces;
using Authentication.Models;
using Authentication.Models.DTOs;
using Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Claims;
using System.Text;

namespace Authentication.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(IUserRepository userRepository, ITokenService tokenService, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<AuthenticationIdentityUser> Register(CreateUserDTO model)
    {
        try
        {
            AuthenticationIdentityUser userData = new()
            {
                Cpf = model.Cpf!,
                BirthDate = model.BirthDate,
                Name = model.Name,
                Email = model.Email,
                UserName = model.Email,
            };

            AuthenticationIdentityUser user = await GetUserByEmailAsync(model.Email);

            if (user != null) throw new Exception("Usuário já cadastrado!");

            var result = await _userRepository.RegisterAsync(userData, model.Password, model.Role);

            if (result.Succeeded)
            {
                user = await GetUserByEmailAsync(model.Email);
                userData.Id = user!.Id;
            }

            return userData;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<string> Login(LoginUserDTO model)
    {
        try
        {
            AuthenticationIdentityUser user = await GetUserByEmailAsync(model.Email) ?? throw new ArgumentNullException(null, "Usuário não encontrado!");

            var loginUser = await _userRepository.LoginAsync(user, model.Password);

            if (!loginUser.Succeeded)
            {
                throw new ArgumentException("E-mail ou senha inválidos!");
            }

            IList<string> roles = await _userRepository.GetUserRolesAsync(user);

            return _tokenService.GenerateToken(user, roles);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<string> ForgotPassword(string email)
    {
        try
        {
            AuthenticationIdentityUser user = await GetUserByEmailAsync(email) ?? throw new Exception("Não existe um usuário com esse endereço de e-mail.");

            var resetToken = _userRepository.GenerateEmailConfirmationTokenAsync(user).Result;

            return resetToken;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IdentityResult> ResetUserPassword(ResetUserPasswordDTO model)
    {
        try
        {
            AuthenticationIdentityUser user = await GetUserByEmailAsync(model.Email);

            IdentityResult passwordResetResponse = await _userRepository.ResetUserPasswordAsync(user, model.ResetToken, model.NewPassword);

            if (!passwordResetResponse.Succeeded) throw new ApplicationException("O token de redefinição de senha já foi utilizado ou é inválido!");

            return passwordResetResponse;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task ChangeUserPassword(ChangeUserPasswordDTO model)
    {
        AuthenticationIdentityUser user = await GetUserByEmailAsync(model.Email);

        await _userRepository.ChangeUserPasswordAsync(user, model.CurrentPassword, model.NewPassword);

    }

    public async Task<AuthenticationIdentityUser> GetUserByEmailAsync(string email)
    {
        AuthenticationIdentityUser user = await _userRepository.GetUserByEmailAsync(email);

        return user;
    }
}
