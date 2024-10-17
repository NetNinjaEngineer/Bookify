using Bookify.Abstractions;
using Bookify.Helpers;

namespace Bookify.Services.Contracts;

public interface IEmailService
{
    Task<Result> SendEmailAsync(Email emailMessage);
}
