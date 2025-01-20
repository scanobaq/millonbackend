using Microsoft.AspNetCore.Http;

namespace Application.DTOs.Property;

public class PropertyDto
{
    public Guid PropertyId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public decimal Price { get; set; }
    public string CodeInternal { get; set; }
    public string Year { get; set; }
    public string OwnerId { get; set; }
    public IFormFile ImageFile { get; set; }
    public string PropertyImagePath { get; set; }
    public string PropertyImageUrl { get; set; }
}
