using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using micropay.Data;
using micropay.Dto;
using micropay.Models;
using micropay.Services.AuthService;
using micropay.Services.UserService;

namespace micropay.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IUserService _userService;

    public UserController(DataContext context, IUserService userService)
    {
        _authService = authService;
        _context = context;
    }

    [HttpPost]
    [Route("register")]
    public async Task<ActionResult<User>> Regiser(UserDto userDto)
    {
        var user = _userService.Create(userDto);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok(user);
    }


}