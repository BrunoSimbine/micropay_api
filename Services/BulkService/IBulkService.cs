using micropay.Dto;
using micropay.Models;
using micropay.ViewModels;

namespace micropay.Services.BulkService;

public interface IBulkService
{
    Task<string> SendInvoice(int TransactionId);
}