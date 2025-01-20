using Microsoft.AspNetCore.Http;

namespace Application.Services;
public class ImageService : IImageService
{
    private readonly string _uploadPath = "wwwroot/uploads";
    private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
    private readonly int _maxFileSize = 10 * 1024 * 1024; // 10 MB

    public async Task<string> SaveImageAsync(IFormFile file)
    {
        if (file == null) return null;

        if (!_allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
            throw new ArgumentException("Invalid file extension");

        if (file.Length > _maxFileSize)
            throw new ArgumentException("File size exceeds the maximum allowed");

        // Crear nombre único para la imagen
        string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        string filePath = Path.Combine(_uploadPath, fileName);

        // Asegurar que el directorio existe
        Directory.CreateDirectory(_uploadPath);

        // Guardar el archivo
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return $"/uploads/{fileName}"; // Retorna la ruta relativa
    }
}
