namespace micropay.ViewModels;

public class TokenViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Account { get; set; } = string.Empty;
}