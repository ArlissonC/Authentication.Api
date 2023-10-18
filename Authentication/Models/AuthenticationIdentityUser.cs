using Microsoft.AspNetCore.Identity;

namespace Authentication.Models;

public class AuthenticationIdentityUser : IdentityUser<Guid>
{
    public string Name { get; set; } = null!;
    public DateTime? BirthDate { get; set; }
    public string? Cpf { get; set; }
}
