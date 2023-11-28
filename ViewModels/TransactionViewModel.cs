namespace micropay.ViewModels;

public class TransactionViewModel
{
    public Guid Id { get; set; }
    public double Amount { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Account { get; set; } = string.Empty;
}