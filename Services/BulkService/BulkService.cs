using System.Security.Claims;
using micropay.Dto;
using micropay.Models;
using micropay.Services.AuthService;
using micropay.ViewModels;

namespace micropay.Services.BulkService;

public class BulkService : IBulkService
{
    private readonly IHttpContextAccessor _accessor;
    private readonly IAuthService _authService;

    public BulkService(IHttpContextAccessor accessor, IAuthService authService)
    {
        _accessor = accessor;
        _authService = authService;
    }
}