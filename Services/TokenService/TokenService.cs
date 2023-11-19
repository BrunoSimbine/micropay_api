using System.Security.Claims;
using micropay.Dto;
using micropay.Models;
using micropay.Services.AuthService;
using micropay.ViewModels;

namespace micropay.Services.TokenService;

public class TokenService : IUserService
{
    private readonly IHttpContextAccessor _accessor;
    private readonly IAuthService _authService;

    public TokenService(IHttpContextAccessor accessor, IAuthService authService)
    {
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

    public Token Create(TokenDto tokenDto)
    {
        var token = new Token()
        {
            Name = tokenDto.Name,
            Type = tokenDto.Type,
            Account = tokenDto.Account
        };
        user.User = 

        return user;
    }
}