using micropay.Dto;
using micropay.Models;
using micropay.ViewModels;

namespace micropay.Services.TransactionService;

public interface ITokenService
{
    Task<string> Create(TransactionDto transactionDto);
    Task<List<TransactionViewModel>> GetTransactions(Token token);
}