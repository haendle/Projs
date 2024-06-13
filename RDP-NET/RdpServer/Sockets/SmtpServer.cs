using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RdpServer.Sockets
{
    internal class SmtpServer
    {
        private string _smtpEmail;
        private string _smtpPassword;

        public SmtpServer(string email, string password) 
        { 
            _smtpEmail = email;
            _smtpPassword = password;
        }

        public void SendRequest(string invitation)
        {
            string[] emails = File.ReadAllLines("smtp.ini");

            var smtpClient = new SmtpClient("smtp.mail.ru", 587);

            var mailMessage = new MailMessage();
            mailMessage.Body = invitation;

            smtpClient.Credentials = new NetworkCredential
            (
                _smtpEmail,
                _smtpPassword
            );

            smtpClient.EnableSsl = true;

            mailMessage.From = new MailAddress(_smtpEmail);
            mailMessage.Subject = "Invitation to RDP-Session";

            foreach (string email in emails)
            {
                mailMessage.To.Add(email);
                smtpClient.Send(mailMessage);
            }
        }
    }
}
