using BlogProject.Application.DTOs.MailDTOs;

namespace BlogProject.Application.Services.MailServices;

public interface IMailServices
{
    Task SendMailAsync(SendMailDTO sendMailDTO);
}
