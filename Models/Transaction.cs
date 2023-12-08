namespace micropay.Models;

public class Transaction
{
    public Token Token { get; set; }
    public Guid TokenId { get; set; }
    public Guid Id { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Paid { get; set; }
    public DateTime Finished { get; set; }
    public double Amount { get; set; }
    public string PayMethod { get; set; } = "Mpesa";
    public string Status { get; set; }
    public string Client { get; set; }
    public string Contact { get; set; }
}