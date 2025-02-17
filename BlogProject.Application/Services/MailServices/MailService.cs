using BlogProject.Application.DTOs.MailDTOs;
using MailKit.Security;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace BlogProject.Application.Services.MailServices;

public class MailService : IMailService
    {
        public async Task SendMailAsync(SendMailDTO sendMailDTO)
        {
		try
		{
			var newMail = new MimeMessage();
			newMail.From.Add(MailboxAddress.Parse("ackuseacademy@gmail.com"));
			newMail.To.Add(MailboxAddress.Parse(sendMailDTO.Email));
			newMail.Subject = sendMailDTO.Subject;
			var builder = new BodyBuilder();
			builder.HtmlBody = sendMailDTO.Message;
			newMail.Body = builder.ToMessageBody();
			var smtp = new SmtpClient();
			await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
			await smtp.AuthenticateAsync("ackuseacademy@gmail.com", "sonlljhuhlxuzpsu");
			await smtp.SendAsync(newMail);
			await smtp.DisconnectAsync(true);
		}
		catch (Exception ex)
		{

			throw new InvalidOperationException($"A problem occured while sending e-mail : {ex.Message}");
		}
        }
    }
