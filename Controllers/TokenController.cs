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
public class TokenController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IAuthService _authService;
    private readonly IUserService _userService;
    public AuthController(DataContext context, IAuthService authService, IUserService userService)
    {
        _authService = authService;
        _userService = userService;
        _context = context;
    }

    [HttpGet]
    [Route("get")]
    public async Task<ActionResult<User>> Regiser()
    {
        return Ok("Ola Mundo!");
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> Login(LoginDto loginDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Phone == loginDto.Phone);
        if (user == null)
            return NotFound("User Not Found");

        if (!_authService.VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt))
            return BadRequest("Wrong Phone or password");

        var token = _authService.CreateToken(user);
        return Ok(new {Token = token});
    }
}

