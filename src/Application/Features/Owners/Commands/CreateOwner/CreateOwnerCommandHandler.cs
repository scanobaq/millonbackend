using MediatR;
using AutoMapper;
using Domain.Entities;
using Application.DTOs.Owner;
using Application.Interfaces.Repositories;

namespace Application.Features.Owners.Commands.CreateOwner;

public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, OwnerDto>
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly IMapper _mapper;

    public CreateOwnerCommandHandler(IOwnerRepository ownerRepository, IMapper mapper)
    {
        _ownerRepository = ownerRepository;
        _mapper = mapper;
    }

    public async Task<OwnerDto> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var owner = _mapper.Map<Owner>(request);
            var createdOwner = await _ownerRepository.CreateAsync(owner);
            return _mapper.Map<OwnerDto>(createdOwner);
        }
        catch (Exception ex)
        {
            throw new Exception("Error creating owner", ex);
        }
    }
}
