namespace micropay.ViewModels;

public class TransactionViewModel
{
    public Guid Id { get; set; }
    public double Amount { get; set; }
    public string FromType { get; set; } = string.Empty;
    public string FromAccount { get; set; } = string.Empty;
}