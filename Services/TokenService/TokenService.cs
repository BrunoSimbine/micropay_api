using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using micropay.Dto;
using micropay.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using micropay.Data;
using micropay.Services.AuthService;
using micropay.ViewModels;

namespace micropay.Services.TokenService;

public class TokenService : ITokenService
{
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _accessor;
    private readonly IAuthService _authService;

    public TokenService(DataContext context, IHttpContextAccessor accessor, IAuthService authService)
    {
        _context = context;
        _accessor = accessor;
        _authService = authService;
    }
    public Guid? GetId()
    {
        var id = _accessor.HttpContext?.User.FindFirstValue(ClaimTypes.Sid);
        return Guid.Parse(id!);
    }

    public async Task<List<TokenViewModel>> GetTokens()
    {
        var id = GetId();
        return await _context.Tokens.Where(p => p.UserId == id).Select(token => new TokenViewModel
        {
            Id = token.Id,
            Name = token.Name,
            Type = token.Type,
            Account = token.Account
        }).ToListAsync();
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

    public async Task<WithdrawTemplate> Withdraw(Guid tokenId)
    {
        var transactions = await _context.Transactions.ToListAsync();
        var result = ConvertToWithdraw(transactions);
        return result;
    }

    public async Task<string> Delete(Guid Id)
    {
        var token = _context.Tokens.FirstOrDefault(e => e.Id == Id);
        _context.Tokens.Remove(token);
        await _context.SaveChangesAsync();
        return "Eliminado";
    }

    private WithdrawTemplate ConvertToWithdraw(List<Transaction> transactions)
    {
        double Total = 0;
        var withdrawItems = new List<WithdrawItem>();
        foreach (var transaction in transactions)
        {
            var item = new WithdrawItem
            {
                TransactionId = transaction.Id,
                Name = transaction.Client,
                OriginalAmount = transaction.Amount
            };

            if (transaction.Provider == "Cash")
            {
                item.Amount = transaction.Amount - 20;
            }
            withdrawItems.Add(item);

            Total += item.Amount;
        }
        
    }
    return new WithdrawTemplate
    {
        Total = Total,
        Items = withdrawItems
    }
    
}