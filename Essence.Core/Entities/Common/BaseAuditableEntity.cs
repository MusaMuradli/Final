namespace Essence.Core.Entities.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    public string CreatedBy { get; set; } = null!;
    public string UpdatedBy { get; set; } = null!;
}
