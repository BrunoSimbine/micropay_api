using System.ComponentModel.DataAnnotations.Schema;

namespace micropay.Models;

public class WithdrawTemplate
{
    public Guid Id { get; set; }
    public double Total { get; set; }
    public bool Confirmed { get; set; }
    [JsonProperty]
    public List<WithdrawItem> Items;
}