using BlogProject.Application.DTOs.MailDTOs;

namespace BlogProject.Application.Services.MailServices;

public interface IMailService
{
    Task SendMailAsync(SendMailDTO sendMailDTO);
}
