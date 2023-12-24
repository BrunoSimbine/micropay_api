using System.ComponentModel.DataAnnotations.Schema;

namespace micropay.Models;

public class WithdrawItem
{
    public string Name { get; set; }
    public int TransactionId { get; set; } 
    public double OriginalAmount { get; set; }
    public double Amount { get; set; }
}