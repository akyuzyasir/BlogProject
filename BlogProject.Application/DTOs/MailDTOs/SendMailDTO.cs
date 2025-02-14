namespace BlogProject.Application.DTOs.MailDTOs;

public class SendMailDTO
{
    public string Message { get; set; } = null!;
    public string Subject { get; set; } = null!;
    public string Email { get; set; } = null!;
}
