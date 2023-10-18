using Authentication.Models;

namespace Authentication.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(AuthenticationIdentityUser user, IList<string> roles);
}
