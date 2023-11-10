namespace micropay.Models;

public class Token
{
    public User User { get; set; }
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Account { get; set; } = string.Empty;
}