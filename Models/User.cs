namespace micropay.Models;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public double Balance { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}