using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace micropay.Models;

public class Withdraw
{
    public Guid Id { get; set; }
    public string User { get; set; }
    public double Total { get; set; }
    public bool Confirmed { get; set; }
    public string Bank { get; set; }
    public string Account { get; set; }
}