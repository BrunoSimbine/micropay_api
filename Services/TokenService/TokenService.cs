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

    public async Task<List<WithdrawItem>> GetWithdraw(Guid tokenId)
    {
        var transactions = await _context.Transactions.Where(e => e.TokenId == tokenId && e.Status == "done").ToListAsync();

        var withdrawItems = new List<WithdrawItem>();
        foreach (var transaction in transactions)
        {
            var item = new WithdrawItem
            {
                TransactionId = transaction.Id,
                Name = transaction.Client,
                OriginalAmount = transaction.Amount,
                Provider = transaction.Provider
            };

            if (transaction.Provider == "Cash")
            {
                item.Amount = -5;
            }else{
                item.Amount = item.OriginalAmount - 20;
            }
            withdrawItems.Add(item);

        }
        return withdrawItems;
    }

    public async Task<string> PayWithdraw(Guid tokenId)
    {

        var transactions = await _context.Transactions.Where(e => e.TokenId == tokenId && e.Status == "done").ToListAsync();
        var token = await _context.Tokens.FirstOrDefaultAsync(e => e.Id == tokenId);
        var user = await _context.Users.FirstOrDefaultAsync(e => e.Id == token.UserId);

        var withdrawItems = new List<WithdrawItem>();

        foreach (var transaction in transactions)
        {
            var item = new WithdrawItem
            {
                TransactionId = transaction.Id,
                Name = transaction.Client,
                OriginalAmount = transaction.Amount,
                Provider = transaction.Provider
            };

            if (transaction.Provider == "Cash")
            {
                item.Amount = -5;
            }else{
                item.Amount = item.OriginalAmount - 20;
            }
            withdrawItems.Add(item);

        }

        double total = 0;
        foreach (var item in withdrawItems)
        {
            total += item.Amount;
        }
        
   

        var withdraw = new Withdraw
        {
            User = user.Name,
            Total = total,
            Type = token.Type,
            Account = token.Account
        };

        _context.Withdraws.Add(withdraw);
        await _context.SaveChangesAsync();

        foreach (var item in transactions)
        {
            var transaction = _context.Transactions.Find(item.Id);
            transaction.WithdrawId = withdraw.Id;
            transaction.Status = "progress";
        }

        await _context.SaveChangesAsync();
        return "Ok";
    }

    public async Task<string> Delete(Guid Id)
    {
        var token = _context.Tokens.FirstOrDefault(e => e.Id == Id);
        _context.Tokens.Remove(token);
        await _context.SaveChangesAsync();
        return "Eliminado";
    }

    
}