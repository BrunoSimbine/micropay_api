namespace micropay.Dto;

public class TransactionDto
{
    public string Amount { get; set; } =  string.Empty;
    public string TokenId { get; set; } = string.Empty;
    public string Client { get; set; } = string.Empty;
}