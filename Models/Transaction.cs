namespace micropay.Models;

public class Transaction
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; } = string.Empty;
    public double Amount { get; set; }
    public string FromType { get; set; } = string.Empty;
    public string FromAccount { get; set; } = string.Empty;
}