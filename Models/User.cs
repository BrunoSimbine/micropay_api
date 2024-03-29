using System.ComponentModel.DataAnnotations.Schema;

namespace micropay.Models;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public bool IsBusiness { get; set; }
    public bool IsVerified { get; set; }
    public string Role { get; set; } = "user";
    public string Phone { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}