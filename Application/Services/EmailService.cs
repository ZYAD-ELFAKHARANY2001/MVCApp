using Application.Contract;
using Application.IServices;
using DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EmailService:IEmailService
    {
        private readonly IBaseRepository<Reminder, int> baseRepository;
        private readonly SmtpSettings _smtpSettings;

        public EmailService(Contract.IBaseRepository<Reminder, int> baseRepository, IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
            this.baseRepository = baseRepository;

        }
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            //var reminder = await baseRepository.GoTo.FirstOrDefaultAsync(r => r.Id == reminderId);
            //if (reminder == null || reminder.IsSent)
            //{
            //    return;
            //}
            Console.WriteLine("Email is Sending");
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpSettings.SenderEmail, _smtpSettings.SenderName),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(to);

            using (var client = new SmtpClient(_smtpSettings.Server, _smtpSettings.Port)
            {
                Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
                EnableSsl = _smtpSettings.EnableSsl
            })
            {
                await client.SendMailAsync(mailMessage);
            }

        }
        public async Task SendReminderEmail(int reminderId)
        {
            var reminder = await baseRepository.GoTo.FirstOrDefaultAsync(r => r.Id == reminderId);
            if (reminder == null || reminder.IsSent)
            {
                return;
            }

            // Assume you have a method to get the recipient email address
            string recipientEmail = "recipient@example.com";

            await SendEmailAsync(
                recipientEmail,
                "Reminder: " + reminder.Title,
                "This is a reminder for: " + reminder.Title);

            // Mark the reminder as sent
            reminder.IsSent = true;
            baseRepository.UpdateAsync(reminder);
            await baseRepository.SaveChangesAsync();
        }
    }
}
