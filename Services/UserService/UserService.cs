using System.Security.Claims;
using micropay.Dto;
using micropay.Models;
using micropay.Services.AuthService;
using micropay.ViewModels;

namespace micropay.Services.UserService;

public class UserService : IUserService
{
    private readonly IHttpContextAccessor _accessor;
    private readonly IAuthService _authService;

    public UserService(IHttpContextAccessor accessor, IAuthService authService)
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

    public User Create(UserDto userDto)
    {
        _authService.CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
        var user = new User()
        {
            Name = userDto.Name,
            Surname = userDto.Surname,
            Phone = userDto.Phone
        };
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        return user;
    }
}