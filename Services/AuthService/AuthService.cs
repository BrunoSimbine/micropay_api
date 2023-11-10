using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using micropay.Models;

namespace micropay.Services.AuthService;

public class AuthService : IAuthService
{
    public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    }

    public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(passwordHash);
    }

    public string CreateToken(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(ClaimTypes.Sid, user.Id.ToString())
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("my top secret key"));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var token = new JwtSecurityToken(claims: claims, expires:DateTime.Now.AddDays(1), signingCredentials:cred);
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
}