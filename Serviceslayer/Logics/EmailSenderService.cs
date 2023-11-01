using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Serviceslayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer.Logics
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmailSenderService(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public void SendEmail(string receiverEmail, string emailSubject, string emailBody)
        {
            string fromAddress = "sender@gmail.com";// _configuration.GetSection<string>("MailSettings:From");

            MailMessage message = new MailMessage(fromAddress, receiverEmail)
            {
                Subject = emailSubject,
                Body = emailBody
            };

            string host = "smtp.gmail.com";//_configuration.GetValue<string>("MailSettings:Server");
            int port = 587;// _configuration.GetValue<int>("MailSettings:Port");

            string userName = "inventionwinning@gmail.com";// _configuration.GetValue<string>("MailSettings:UserName");
            string password = "wglrbazdimksuilm";// _configuration.GetValue<string>("MailSettings:Password");
            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.Host = host;
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(userName, password);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = port;
                message.IsBodyHtml = true;
                smtp.Send(message);
            }
        }
        public async void SendTemporaryPassword(string FirstName, string password, string Email)
        {
            var emailBody = $"Hello {FirstName}, your temporary password is {password}. Please change it after logging in.";

            var emailSubject = "Temporary Password";
            //var emails = await _emailTemplateRepository.Get(x => x.EmailType == "TemporaryPassword" && x.Language == PreferedLanguage);

            //if (emails == null)
            //{
            //    emails = await _emailTemplateRepository.Get(x => x.EmailType == "TemporaryPassword" && x.Language == UserDefinedConstant.DefaultLanguage);
            //}

            //// var emails = await _emailTemplateRepository.Get(x => x.EmailType == "TemporaryPassword");

            //var template = Handlebars.Compile(emails.EmailBody);

            //var data = new
            //{
            //    UserName = FirstName,
            //    TemporaryPassword = password

            //};

            //var result = template(data);

            SendEmail(Email, emailSubject, emailBody);
        }
        public async void SendMailForChangePassword(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            var emailBody = $"Hello {user.UserName}, your password is changed.";
            var emailSubject = "Password reset ";
            SendEmail(Email, emailSubject, emailBody);

        }
        public async void SendTokenForResetPassword(string UserName, string token, string Email)
        {
            var emailBody = $"Hello {UserName}, your token is {token}.";
            var emailSubject = "ResetPassword ";
            SendEmail(Email, emailSubject, emailBody);

        }
    }
}
