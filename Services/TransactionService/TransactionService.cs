using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using micropay.Dto;
using micropay.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using micropay.Data;
using micropay.Services.AuthService;
using micropay.ViewModels;

namespace micropay.Services.TransactionService;

public class TransactionService : ITransactionService
{
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _accessor;

    public TransactionService(DataContext context, IHttpContextAccessor accessor, IAuthService authService)
    {
        _context = context;
        _accessor = accessor;
    }
    public Guid? GetId()
    {
        var id = _accessor.HttpContext?.User.FindFirstValue(ClaimTypes.Sid);
        return Guid.Parse(id!);
    }

    public async Task<List<TransactionViewModel>> GetTransactions(Token token)
    {
        var id = GetId();
        if (token.UserId == id)
        {
            return await _context.Transactions.Where(p => p.TokenId == token.Id).Select(transaction => new TransactionViewModel
            {
                Id = transaction.Id,
                Created = transaction.Created,
                Paid = transaction.Paid,
                Finished = transaction.Finished,
                Status = transaction.Status,
                Amount = transaction.Amount,
                Client = transaction.Client,
                Contact = transaction.Contact
            }).ToListAsync();
        }else{
            var tokens = new List<TransactionViewModel>();
            return tokens;
        }
    }

    public async Task<string> Create(TransactionDto transactionDto)
    {
        var id = GetId();
        var token = _context.Tokens.FirstOrDefault(e => e.UserId == id && e.Id == Guid.Parse(transactionDto.TokenId));
        var transaction = new Transaction()
        {
            Status = "pending",
            Client = transactionDto.Client,
            Contact = transactionDto.Contact,
            Amount = transactionDto.Amount
        };
        transaction.Token = token;
        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();

        return "Criado com sucesso";
    }

    public async Task<string> Delete(Guid Id)
    {
        var transaction = _context.Transactions.FirstOrDefault(e => e.Id == Id);
        _context.Remove(transaction);
        await _context.SaveChangesAsync();
        return "Eliminado";
    }

    public async Task<string> Pay(Guid Id, string Provider)
    {
        var transaction = _context.Find(e => e.Id == Id);
        transaction.Provider = Provider;
        transaction.Paid = DateTime.Now;
        transaction.Status = "done";
        await _context.SaveChangesAsync();
        return "Concluido!";
    }

    public async Task<string> PayDirect(Guid Id)
    {
        var transaction = _context.Find(e => e.Id == Id);
        transaction.Provider = "Cash";
        transaction.Paid = DateTime.Now;
        transaction.Status = "done";
        await _context.SaveChangesAsync();
        return "Concluido!";
    }

    
}