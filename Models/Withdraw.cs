using System.ComponentModel.DataAnnotations.Schema;

namespace micropay.Models;

public class User
{
    public Guid Id { get; set; }
    public double Total { get; set; }
    public List<Transaction> transactions;
}