using Authentication.Data.Interfaces;
using Authentication.Models;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Data.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly RoleManager<AuthenticationIdentityRoles> _roleManager;

    public AdminRepository(RoleManager<AuthenticationIdentityRoles> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task RegisterRolesAsync(List<string> roles)
    {
        try
        {
            foreach (var roleName in roles)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    AuthenticationIdentityRoles role = new() { Name = roleName };

                    await _roleManager.CreateAsync(role);
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
