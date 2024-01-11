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
        _userService = userService;
        _context = context;
    }

    [HttpGet, Authorize]
    [Route("get")]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        return Ok();
    }

    [HttpGet, Authorize]
    [Route("get/inactive")]
    public async Task<ActionResult<List<User>>> GetInactiveUsers()
    {
        return Ok();
    }

    [HttpPost, Authorize]
    [Route("get/business")]
    public async Task<ActionResult<List<User>>> GetBusinessUsers()
    {
        return Ok();
    }


}