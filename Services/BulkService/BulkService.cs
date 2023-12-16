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