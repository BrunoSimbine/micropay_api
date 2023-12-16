using micropay.Dto;
using micropay.Models;
using micropay.ViewModels;

namespace micropay.Services.TokenService;

public interface IBulkService
{
    Task<string> SendInvoice(int TransactionId);
}