using Essence.Core.Entities.Common;
namespace Essence.Core.Entities;

public class Subscriber : BaseEntity
{
    public string Email { get; set; } = null!;
}
