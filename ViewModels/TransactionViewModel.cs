namespace micropay.ViewModels;

public class TransactionViewModel
{
    public Guid Id { get; set; }
    public double Amount { get; set; }
    public string Status { get; set; }
    public DateTime Created { get; set; }
    public DateTime Paid { get; set; }
    public DateTime Finished { get; set; }
    public string Client { get; set; }
    public string Contact { get; set; }
    public string Provider { get; set; }
    
}