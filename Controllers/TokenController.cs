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
using micropay.Services.AuthService;

namespace micropay.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TokenController : ControllerBase
{
    private readonly DataContext _context;
    public TokenController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("get")]
    public async Task<ActionResult<User>> GetAll()
    {
        return Ok("Ola Mundo!");
    }
}

