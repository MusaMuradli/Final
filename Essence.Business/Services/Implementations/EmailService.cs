using Essence.Business.Dtos.EmailDtos;
using Essence.Business.Services.Abstractions;
using Microsoft.Extensions.Configuration;

namespace Essence.Business.Services.Implementations;

internal class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Task SendEmailAsync(EmailSendDto dto)
    {
        throw new NotImplementedException();
    }
}
