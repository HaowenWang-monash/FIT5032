using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace _5032_Assignment.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents)
        {
            
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("1253040642@qq.com", "Medibook system");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }

    }
}