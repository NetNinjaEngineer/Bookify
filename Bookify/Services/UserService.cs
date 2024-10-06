using Bookify.Services.Contracts;
using System.Security.Claims;

namespace Bookify.Services;

public class UserService : IUserService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public UserService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public string UserEmail => _contextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.Email)!;
}
