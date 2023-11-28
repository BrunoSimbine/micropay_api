namespace micropay.Models;

public class Transaction
{
    public Token Token { get; set; }
    public Guid TokenId { get; set; }
    public Guid Id { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public double Amount { get; set; }
}