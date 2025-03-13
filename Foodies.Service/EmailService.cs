using Foodies.Core.IServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Foodies.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var client = new SmtpClient(_configuration["Email:SmtpServer"], int.Parse(_configuration["Email:Port"]))
            {
                Credentials = new NetworkCredential(_configuration["Email:Username"], _configuration["Email:Password"]),
                EnableSsl = true
            };

            await client.SendMailAsync(new MailMessage(_configuration["Email:Username"], to, subject, body));
        }
    }
}
