using CleanArchitecture.Application.Services.Email;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;

namespace CleanArchitecture.Application.Services;

public class EmailSender : IEmailSender
{
    private readonly EmailConfiguration _emailConfig;
    private readonly ILogger<EmailSender> _logger;

    public EmailSender(IOptions<EmailConfiguration> emailConfig, ILogger<EmailSender> logger)
    {
        _emailConfig = emailConfig.Value;
        _logger = logger;
    }


    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        if (string.IsNullOrWhiteSpace(toEmail))
        {
            throw new ArgumentException("O endereço de e-mail do destinatário não pode ser vazio.");
        }

        var smtpClient = new SmtpClient(_emailConfig.SmtpServer)
        {
            Port = _emailConfig.Port,
            Credentials = new NetworkCredential(_emailConfig.UserName, _emailConfig.Password),
            EnableSsl = true
        };

        var mailMessage = new MailMessage()
        {
            From = new MailAddress(_emailConfig.UserName, "ReserveAqui"),
            Subject = subject,
            Body = message,
            IsBodyHtml = true,
        };

        mailMessage.To.Add(toEmail);

        try
        {
            await smtpClient.SendMailAsync(mailMessage);
            _logger.LogInformation($"Email sent successfully to {toEmail}");
        }
        catch(Exception ex)
        {
            _logger.LogError($"Error sending email: {ex.Message}");
            throw new Exception("Error sending email ", ex);
        }

    }

    

    
}
