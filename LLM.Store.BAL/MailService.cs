using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.Interfaces.Bal;
using LLM.Store.ApplicationCore.ViewModels;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LLM.Store.BAL
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }


        public async Task<bool> SendWelcomeEmailAsync(WelcomeRequest request)
        {
            string FilePath = Directory.GetCurrentDirectory() + "\\Templates\\WelcomeTemplate.html3";
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();

            try
            {

                MimeMessage emailMessage = new MimeMessage();

                MailboxAddress emailFrom = new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail);
                emailMessage.From.Add(emailFrom);
                string[] toEmails = request.ToEmail.Split(",");
                foreach (string toEmail in toEmails)
                {
                 
                    emailMessage.To.Add(MailboxAddress.Parse(toEmail));
                }

                if (request.Cc != null)
                {
                    string[] ccEmails = request.Cc.Split(",");
                    foreach (string ccEmail in ccEmails)
                    {

                        emailMessage.Cc.Add(MailboxAddress.Parse(ccEmail));
                    }
                }

                if (request.Bcc != null)
                {
                    string[] bccEmails = request.Bcc.Split(",");
                    foreach (string bccEmail in bccEmails)
                    {

                        emailMessage.Bcc.Add(MailboxAddress.Parse(bccEmail));
                    }

                }
                emailMessage.Subject = $"Welcome {request.UserName}";
                var builder = new BodyBuilder();
                builder.HtmlBody = MailText;
                emailMessage.Body = builder.ToMessageBody();
                SmtpClient emailClient = new SmtpClient();
                emailClient.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                emailClient.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await emailClient.SendAsync(emailMessage);
                emailClient.Disconnect(true);
                emailClient.Dispose();
         
                return true;
            }
            catch (Exception ex)
            {

                return false;
                
            }
        }
    }
}

