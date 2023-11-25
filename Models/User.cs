using System.ComponentModel.DataAnnotations.Schema;

namespace micropay.Models;

[Index(nameof(Phone), IsUnique = true)]
public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Role { get; set; } = "user";
    public string Phone { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}