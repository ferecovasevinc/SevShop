using Microsoft.Extensions.Options;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.Shared.Settings;
using System.Net.Mail;
using System.Net;

namespace SevShop.Infrastructure.Services;

public class EmailService : IEmailService
{
    private EmailSettings _emailSettings { get; }

    public EmailService(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    public async Task SendEmailAsync(IEnumerable<string> toEmails, string subject, string body)
    {
        using var smtp = new SmtpClient(_emailSettings.SmtpHost, _emailSettings.SmtpPort)
        {
            Credentials = new NetworkCredential(_emailSettings.SenderEmail, _emailSettings.Password),
            EnableSsl = true
        };

        var message = new MailMessage
        {
            From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };

        foreach (var email in toEmails)
        {
            message.To.Add(email);
        }

        await smtp.SendMailAsync(message);
    }

}

