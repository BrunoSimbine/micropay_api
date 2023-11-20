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

    public List<UserViewModel> GetUsers(List<User> users)
    {
        return users.Select(user => new UserViewModel
        {
            Id = user.Id,
            Name = user.Name,
            Surname = user.Surname
        }).ToList();
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
        user.UserId = id;
        _context.Tokens.Add(token);
        await _context.SaveChangesAsync();

        return "Criado com sucesso";
    }
}