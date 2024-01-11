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
public class PaymentController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IPaymentService _paymentService;
    public PaymentController(DataContext context, IPaymentService paymentService)
    {
        _paymentService = paymentService;
        _context = context;
    }

    [HttpPost]
    [Route("mpesa")]
    public async Task<ActionResult<bool>> PayWithMpesa([FromQuery] int transactionId)
    {
        return Ok();
    }

    [HttpPost]
    [Route("emola")]
    public async Task<ActionResult<bool>> PayWithEmola([FromQuery] int transactionId)
    {
        return Ok();
    }

    [HttpPost]
    [Route("mpesa/direct")]
    public async Task<ActionResult<bool>> PayDirectWithMpesa(TransactionViewModel transactionViewModel)
    {
        return Ok();
    }

    [HttpPost]
    [Route("emola/direct")]
    public async Task<ActionResult<bool>> PayDirectWithEmola(TransactionViewModel transactionViewModel)
    {
        return Ok();
    }

    [HttpPost]
    [Route("card")]
    public async Task<ActionResult<bool>> PayWithCard()
    {
        return Ok();
    }



}