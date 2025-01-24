using Essence.Business.Abstractions.Dtos;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Essence.Business.Dtos.CategoryDtos;

public class CategoryCreateDto : IDto
{
    public IFormFile? Image { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    //public string ImagePath { get; set; } = null!;

}
