using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using micropay.Models;
using micropay.Dto;
using micropay.Data;

namespace micropay.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly DataContext _context;
    public AuthController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("users")]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();
        return Ok(users);
    }

    [HttpPost("create")]
    public async Task<ActionResult<User>> Create(UserDto userDto)
    {
        var user = new User
        {
            Name = userDto.Name,
            Password = userDto.Password,
            Phone = userDto.Phone,
            Surname = userDto.Surname
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok("Criado com sucesso");
    }
}