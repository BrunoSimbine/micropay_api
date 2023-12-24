using System.ComponentModel.DataAnnotations.Schema;

namespace micropay.Models;

public class WithdrawItem
{
    public string Name { get; set; }
    public int TransactionId { get; set; } 
    public double OriginalValue { get; set; }
    public double Value { get; set; }
}