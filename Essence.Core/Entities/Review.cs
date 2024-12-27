﻿using Essence.Core.Entities.Common;

namespace Essence.Core.Entities;

public class Review:BaseAuditableEntity
{
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public string UserId { get; set; } =null!;
    public AppUser User { get; set; } = null!;
    public int ProductId { get; set; } 
    public Product Product { get; set; } = null!;
}
