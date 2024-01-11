namespace micropay.Models;

public class Document
{
    public User User { get; set; }
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}