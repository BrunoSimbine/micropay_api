using micropay.Dto;
using micropay.Models;
using micropay.ViewModels;

namespace micropay.Services.TokenService;

public interface ITokenService
{
    Task<string> Create(TokenDto tokenDto);
    Task<List<TokenViewModel>> GetTokens();
}