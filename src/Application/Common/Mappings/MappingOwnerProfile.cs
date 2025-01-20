namespace Application.Common.Mappings;

using AutoMapper;
using Domain.Entities;
using Application.DTOs.Owner;
using Application.Features.Owners.Commands.CreateOwner;

public class MappingOwnerProfile : Profile
{
    public MappingOwnerProfile()
    {
        CreateMap<Owner, OwnerDto>().ReverseMap();
        CreateMap<CreateOwnerCommand, Owner>().ReverseMap();
    }
}
