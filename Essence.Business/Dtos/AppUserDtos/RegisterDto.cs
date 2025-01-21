using Essence.Business.Abstractions.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Essence.Business.Dtos.AppUserDtos;

public class RegisterDto : IDto
{
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
}
