using Essence.Business.Abstractions.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CloudinaryOptionsDto : IDto
{
    public string APIKey { get; set; } = null!;
    public string APISecret { get; set; } = null!;
    public string CloudName { get; set; } = null!;

}
