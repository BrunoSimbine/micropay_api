using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using micropay.Data;
using micropay.Dto;
using micropay.Models;
using micropay.ViewModels;
using micropay.Services.AuthService;
using micropay.Services.AuthService;

namespace micropay.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TokenController : ControllerBase
{
    private readonly DataContext _context;
    private readonly ITokenService _tokenService;
    public TokenController(DataContext context, ITokenService tokenService)
    {
        _tokenService = tokenService;
        _context = context;
    }

    [HttpGet]
    [Route("get")]
    public async Task<ActionResult<TokenViewModel>> GetAll()
    {
        return Ok("Ola Mundo!");
    }
}

