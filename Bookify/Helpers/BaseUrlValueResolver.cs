namespace Bookify.Helpers;

public abstract class BaseUrlValueResolver
{
    protected readonly IHttpContextAccessor _contextAccessor;

    protected BaseUrlValueResolver(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }
}