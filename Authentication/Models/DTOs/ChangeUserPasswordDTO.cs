namespace Authentication.Models.DTOs;

public class ChangeUserPasswordDTO
{
    public string Email { get; set; } = null!;
    public string CurrentPassword { get; set; } = null!;
    public string NewPassword { get; set; } = null!;
}
