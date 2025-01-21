using Essence.Business.Abstractions.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Essence.Business.Dtos.AppUserDtos;

public class VerifyEmailDto : IDto
{
    [Required(ErrorMessage = "E-poçt sahəsi boş ola bilməz.")]
    [EmailAddress(ErrorMessage = "Düzgün e-poçt ünvanı formatı deyil.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Token sahəsi boş ola bilməz.")]
    public string Token { get; set; } = null!;
}
