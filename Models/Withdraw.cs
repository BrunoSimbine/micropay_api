using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace micropay.Models;

public class WithdrawTemplate
{
    public Guid Id { get; set; }
    public double Total { get; set; }
    public bool Confirmed { get; set; }
    public List<WithdrawItem> Items;
}