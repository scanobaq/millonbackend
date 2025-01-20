using System.ComponentModel.DataAnnotations;
using Application.DTOs.Property;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Properties.Commands.CreateProperty;

public class CreatePropertyCommand : IRequest<PropertyDto>
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public string CodeInternal { get; set; }
    [Required]
    public string Year { get; set; }
    [Required]
    public string OwnerId { get; set; }
    [Required]
    public IFormFile ImageFile { get; set; }

}
