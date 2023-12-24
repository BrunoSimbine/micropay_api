using System.ComponentModel.DataAnnotations.Schema;

namespace micropay.Models;

public class Withdraw
{
    public Guid Id { get; set; }
    public double Total { get; set; }
    public List<Transaction> transactions;
}