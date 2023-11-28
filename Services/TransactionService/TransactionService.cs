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
                Finished = transaction.Finished,
                Status = transaction.Status,
                Type = transaction.Type,
                Account = transaction.Account,
                Amount = transaction.Amount
            }).ToListAsync();
        }else{
            var tokens = new List<TransactionViewModel>();
            return tokens;
        }
    }

    public async Task<string> Create(TokenDto tokenDto)
    {
        var id = GetId();
        var user = _context.Users.FirstOrDefault(e => e.Id == id);
        var token = new Token()
        {
            Name = tokenDto.Name,
            Type = tokenDto.Type,
            Account = tokenDto.Account
        };
        token.User = user;
        _context.Tokens.Add(token);
        await _context.SaveChangesAsync();

        return "Criado com sucesso";
    }