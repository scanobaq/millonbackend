using Microsoft.AspNetCore.Http;

namespace Application.Services;

public interface IImageService
{
    Task<string> SaveImageAsync(IFormFile file);

}
