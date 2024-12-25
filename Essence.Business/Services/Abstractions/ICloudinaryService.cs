using Microsoft.AspNetCore.Http;
namespace Essence.Business.Services.Abstractions;

public interface ICloudinaryService
{
    Task<string> FileCreateAsync(IFormFile file);
    Task<bool> FileDeleteAsync(string filePath);
}