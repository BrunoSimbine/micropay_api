using micropay.Dto;
using micropay.Models;
using micropay.ViewModels;

namespace micropay.Services.TransactionService;

public interface ITransactionService
{
    Task<string> Create(TransactionDto transactionDto);
    Task<List<TransactionViewModel>> GetTransactions(Token token);
    Task<string> Delete(Guid Id);
}