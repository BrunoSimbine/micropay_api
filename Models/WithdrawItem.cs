using System.ComponentModel.DataAnnotations.Schema;

namespace micropay.Models;

public class WithdrawItem
{
    public string Name { get; set; }
    public Guid TransactionId { get; set; } = string.Empty;
    public double OriginalValue { get; set; }
    public double Value { get; set; }
}