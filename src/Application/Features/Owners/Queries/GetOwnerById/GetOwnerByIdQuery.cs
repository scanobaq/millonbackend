using Application.DTOs.Owner;
using MediatR;

namespace Application.Features.Owners.Queries.GetOwnerById;

public record GetOwnerByIdQuery : IRequest<OwnerDto>
{
    public string Id { get; init; }

    public GetOwnerByIdQuery(string id)
    {
        Id = id;
    }
}