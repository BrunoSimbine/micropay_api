using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using micropay.Data;
using micropay.Dto;
using micropay.Models;
using micropay.ViewModels;
using micropay.Services.AuthService;
using micropay.Services.TokenService;

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

    [HttpGet, Authorize]
    [Route("get")]
    public async Task<ActionResult<TokenViewModel>> GetAll()
    {
        var tokens = await _tokenService.GetTokens();
        return Ok(tokens);
    }

    [HttpPost, Authorize]
    [Route("create")]
    public async Task<ActionResult<string>> Create(TokenDto tokenDto)
    {
        var result = await _tokenService.Create(tokenDto);
        return Ok(result);
    }

    [HttpPost, Authorize]
    [Route("withdraw")]
    public async Task<ActionResult<string>> Withdraw(TokenDto tokenDto)
    {
        var result = await _tokenService.Create(tokenDto);
        return Ok(result);
    }

    [HttpDelete, Authorize]
    [Route("delete")]
    public async Task<ActionResult<string>> Create([FromQuery] Guid Id)
    {
        var result = await _tokenService.Delete(Id);
        return Ok(result);
    }


}

