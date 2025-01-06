namespace Essence.Core.Entities.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;

}
