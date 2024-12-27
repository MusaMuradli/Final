using Essence.Core.Entities.Common;

namespace Essence.Core.Entities;

public class Setting: BaseEntity
{
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;

}
