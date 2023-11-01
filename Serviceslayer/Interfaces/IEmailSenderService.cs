using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer.Interfaces
{
    public interface IEmailSenderService
    {
        void SendEmail(string receiverEmail, string emailSubject, string emailBody);
        void SendTemporaryPassword(string FirstName, string password, string Email);
        void SendMailForChangePassword(string Email);
        void SendTokenForResetPassword(string UserName, string token, string Email);
    }
}
