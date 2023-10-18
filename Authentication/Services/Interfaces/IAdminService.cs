using Authentication.Models.DTOs;

namespace Authentication.Services.Interfaces;

public interface IAdminService
{
    Task RegisterRoles(RegisterRolesDTO model);
}
