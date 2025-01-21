using Essence.Business.Abstractions.Dtos;

namespace Essence.Business.Dtos.EmailDtos;

public class MailKitConfigurationDto : IDto
{
    public string Mail { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Host { get; set; } = null!;
    public string Port { get; set; } = null!;
}
