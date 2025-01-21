using Essence.Business.Dtos.EmailDtos;

namespace Essence.Business.Services.Abstractions;

public interface IEmailService
{
    Task SendEmailAsync(EmailSendDto dto);
}
