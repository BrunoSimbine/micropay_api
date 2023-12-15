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
using micropay.Services.TransactionService;

namespace micropay.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly DataContext _context;
    private readonly ITransactionService _transactionService;
    public TransactionController(DataContext context, ITransactionService transactionService)
    {
        _transactionService = transactionService;
        _context = context;
    }

    [HttpGet, Authorize]
    [Route("get")]
    public async Task<ActionResult<TransactionViewModel>> GetAll([FromQuery] Guid tokenId)
    {
        var token = await _context.Tokens.FirstOrDefaultAsync(e => e.Id == tokenId);
        var transactions = await _transactionService.GetTransactions(token);
        return Ok(transactions);
    }

    [HttpPost, Authorize]
    [Route("create")]
    public async Task<ActionResult<string>> Create(TransactionDto transactionDto)
    {
        var result = await _transactionService.Create(transactionDto);
        return Ok(result);
    }

    [HttpPut, Authorize]
    [Route("pay/direct")]
    public async Task<ActionResult<string>> PayWithCash([FromQuery] int Id)
    {
        var result = await _transactionService.PayDirect(Id);
        return Ok(result);
    }

    [HttpPut, Authorize]
    [Route("pay")]
    public async Task<ActionResult<string>> Pay([FromQuery] int Id, [FromQuery] string Provider)
    {
        var result = await _transactionService.Pay(Id, Provider);
        return Ok(result);
    }

    [HttpDelete, Authorize]
    [Route("delete")]
    public async Task<ActionResult<string>> Delete([FromQuery] int Id)
    {
        var result = await _transactionService.Delete(Id);
        return Ok("Apagado");
    }


}