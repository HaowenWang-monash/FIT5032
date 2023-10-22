// using SendGrid's C# Library
// https://github.com/sendgrid/sendgrid-csharp
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Example
{
    internal class Example
    {
        private static void Main()
        {
            Execute().Wait();
        }

        static async Task Execute()
        {
            var apiKey = Environment.GetEnvironmentVariable("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");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("1253040642@qq.com", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("hwan0271@student.monash.edu", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}