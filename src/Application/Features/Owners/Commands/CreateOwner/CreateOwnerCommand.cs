
using System.ComponentModel.DataAnnotations;
using Application.DTOs.Owner;
using MediatR;
namespace Application.Features.Owners.Commands.CreateOwner;
public class CreateOwnerCommand : IRequest<OwnerDto>
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Address { get; set; }

    public string Photo { get; set; }

}
