using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Essence.Business.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;


namespace Essence.Business.Services.Implementations;

internal class CloudinaryService : ICloudinaryService
{
    private readonly IConfiguration _configuration;

    public Task<string> FileCreateAsync(IFormFile file)
    {
        throw new NotImplementedException();
    }

    public Task<bool> FileDeleteAsync(string filePath)
    {
        throw new NotImplementedException();
    }
}
