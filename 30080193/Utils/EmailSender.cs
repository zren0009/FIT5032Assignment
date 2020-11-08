using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.UI;
using System.IO;

namespace _30080193.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents, String userName)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("rezc123abc@gmail.com", userName);
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }

        public void SendBulkEmail(String toEmail, String subject, String contents, String userName, String filePath, String fileName)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("rezc123abc@gmail.com", userName);
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var attachment = File.ReadAllBytes(filePath);
            msg.AddAttachment(fileName, Convert.ToBase64String(attachment));
            var response = client.SendEmailAsync(msg);
        }

    }
}