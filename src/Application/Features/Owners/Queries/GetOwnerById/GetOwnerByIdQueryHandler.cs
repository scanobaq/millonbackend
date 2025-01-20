using Application.DTOs.Owner;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Owners.Queries.GetOwnerById;

public class GetOwnerByIdQueryHandler : IRequestHandler<GetOwnerByIdQuery, OwnerDto>
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly IMapper _mapper;

    public GetOwnerByIdQueryHandler(IOwnerRepository ownerRepository, IMapper mapper)
    {
        _ownerRepository = ownerRepository;
        _mapper = mapper;
    }

    public async Task<OwnerDto> Handle(GetOwnerByIdQuery request, CancellationToken cancellationToken)
    {
        var owner = await _ownerRepository.GetByIdAsync(request.Id);

        if (owner == null)
        {
            throw new KeyNotFoundException($"Owner with ID {request.Id} was not found.");
        }

        return _mapper.Map<OwnerDto>(owner);
    }
}