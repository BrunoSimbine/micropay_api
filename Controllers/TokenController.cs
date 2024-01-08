using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Collections.Generic;
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
    [Route("withdraw/get")]
    public async Task<ActionResult<WithdrawTemplate>> GetWithdraw([FromQuery] Guid Id, [FromQuery] string Bank)
    {
        var items = await _tokenService.GetWithdraw(Id);
        double total = 0;
        foreach (var item in items)
        {
            total += item.Amount;
        }
        return Ok(new {Total = total, Items = items, Fee = new {Bank, Value = 10}});
    }

    [HttpPost, Authorize]
    [Route("withdraw/pay")]
    public async Task<ActionResult<string>> PayWithdraw([FromQuery] Guid Id)
    {
        var result = await _tokenService.PayWithdraw(Id);
        return Ok(result);
    }

    [HttpDelete, Authorize]
    [Route("delete")]
    public async Task<ActionResult<string>> Delete([FromQuery] Guid Id)
    {
        var result = await _tokenService.Delete(Id);
        return Ok(result);
    }


}

