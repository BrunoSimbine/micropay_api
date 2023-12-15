namespace micropay.ViewModels;

public class TransactionViewModel
{
    public int Id { get; set; }
    public double Amount { get; set; }
    public string Status { get; set; }
    public string Created { get; set; }
    public string Paid { get; set; }
    public string Finished { get; set; }
    public string Client { get; set; }
    public string Contact { get; set; }
    public string Provider { get; set; }
    
}