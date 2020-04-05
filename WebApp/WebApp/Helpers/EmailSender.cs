using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace WebApp.Helpers
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            Execute(email, subject, message).Wait();
            return Task.CompletedTask;
        }

        static async Task Execute(string email, string subjectMessage, string message)
        {
            var apiKey = Environment.GetEnvironmentVariable("SendGridAPI");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("noreply@hekatlon.com", "Hekatlon");
            var subject = subjectMessage;
            var to = new EmailAddress(email);
            var plainTextContent = message;
            var htmlContent = message + " <strong>Za namene hekatlona.</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}