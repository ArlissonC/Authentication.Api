using Authentication.Data.Interfaces;
using Authentication.Models.DTOs;
using Authentication.Services.Interfaces;

namespace Authentication.Services;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;

    public AdminService(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task RegisterRoles(RegisterRolesDTO model)
    {
        try
        {
            await _adminRepository.RegisterRolesAsync(model.Roles);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
