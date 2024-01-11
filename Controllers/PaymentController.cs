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

    [HttpGet]
    [Route("mpesa")]
    public async Task<ActionResult<bool>> PayWithMpesa([FromQuery] int TransactionId)
    {
        return Ok();
    }



}