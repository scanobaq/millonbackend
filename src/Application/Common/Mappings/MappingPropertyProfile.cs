
namespace Application.Common.Mappings;

using AutoMapper;
using Domain.Entities;
using Application.DTOs.Property;
using Application.Features.Properties.Commands.CreateProperty;
using Application.Features.Properties.Queries.GetPropertyFilter;

public class MappingPropertyProfile : Profile
{
    public MappingPropertyProfile()
    {
        CreateMap<Property, PropertyDto>().ReverseMap();
        CreateMap<CreatePropertyCommand, Property>().ReverseMap();
        CreateMap<GetPropertiesByFilterQuery, PropertyFilterDto>().ReverseMap();
    }
}
