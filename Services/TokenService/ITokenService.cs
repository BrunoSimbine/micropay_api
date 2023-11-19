using micropay.Dto;
using micropay.Models;
using micropay.ViewModels;

namespace micropay.Services.TokenService;

public interface ITokenService
{
    string Create(TokenDto tokenDto);
}