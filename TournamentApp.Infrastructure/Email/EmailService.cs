using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using TournamentApp.Application.Common.Configs;
using TournamentApp.Application.Interfaces;

namespace TournamentApp.Infrastructure.Email;
public class EmailService : IEmailService
{
    private readonly EmailConfig _emailConfig;

    public EmailService(IOptions<EmailConfig> emailConfig)
    {
        _emailConfig = emailConfig.Value;
    }

    public async Task SendAsync(string to, string subject, string html, string from = null)
    {
        // create message
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(from ?? _emailConfig.EmailFrom));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;
        email.Body = new TextPart(TextFormat.Html) { Text = html };

        // send email
        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_emailConfig.SmtpHost, _emailConfig.SmtpPort, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_emailConfig.SmtpUser, _emailConfig.SmtpPass);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}
