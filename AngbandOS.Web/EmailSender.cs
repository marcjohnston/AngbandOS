﻿using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
namespace AngbandOS.Web
{
    internal class EmailSender : IEmailSender
    {
        private string SmtpAccount;
        private string SmtpPassword;
        private string SmtpFromName;
        private string SmtpHost;
        private int SmtpPort;
        private bool SmtpEnableSsl;


        public EmailSender(IConfiguration configuration)
        {
            SmtpAccount = configuration["Smtp:Account"];
            SmtpPassword = configuration["Smtp:Password"];
            SmtpFromName = configuration["Smtp:FromName"];
            SmtpHost = configuration["Smtp:Host"];
            SmtpPort = configuration.GetValue<int>("Smtp:Port");
            SmtpEnableSsl = configuration.GetValue<bool>("Smtp:EnableSsl");
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SmtpClient client = new SmtpClient
            {
                Port = SmtpPort,
                Host = SmtpHost,
                EnableSsl = SmtpEnableSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(SmtpAccount, SmtpPassword)
            };
            MailMessage mailMessage = new MailMessage()
            {
                Subject = subject,
                IsBodyHtml = true,
                Body = htmlMessage,
                From = new MailAddress(SmtpAccount, SmtpFromName),
            };
            mailMessage.To.Add(new MailAddress(email));

            return client.SendMailAsync(mailMessage);
        }
    }
}
