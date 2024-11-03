using Bookify.Abstractions;
using Bookify.Helpers;
using Bookify.Services.Contracts;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Bookify.Services;

public class EmailService(IOptions<EmailSettings> settings) : IEmailService
{
    private readonly EmailSettings _settings = settings.Value;

    public async Task<Result> SendEmailAsync(Email emailMessage)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Bookify", _settings.Username));
        message.To.Add(new MailboxAddress("Recipient", emailMessage.To));
        message.Subject = emailMessage.Subject;

        message.Body = new TextPart("plain")
        {
            Text = emailMessage.Body
        };

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync(_settings.SmtpServer, _settings.SmtpPort, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_settings.Username, _settings.Password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }

        return Result.Ok();
    }
}