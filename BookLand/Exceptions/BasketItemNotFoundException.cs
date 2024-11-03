namespace Bookify.Exceptions;

public class BasketItemNotFoundException : Exception
{
    public BasketItemNotFoundException(string message) : base(message)
    {
    }
}
