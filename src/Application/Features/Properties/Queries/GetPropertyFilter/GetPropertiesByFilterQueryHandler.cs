using MediatR;
using AutoMapper;
using Application.Common.Wrappers;
using Application.DTOs.Property;
using Application.Interfaces.Repositories;
using Domain.Exceptions.Property;

namespace Application.Features.Properties.Queries.GetPropertyFilter;

public class GetPropertiesByFilterQueryHandler
    : IRequestHandler<GetPropertiesByFilterQuery, PaginatedResponse<PropertyDto>>
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly IMapper _mapper;

    public GetPropertiesByFilterQueryHandler(
       IPropertyRepository propertyRepository,
       IMapper mapper)
    {
        _propertyRepository = propertyRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedResponse<PropertyDto>> Handle(
        GetPropertiesByFilterQuery request,
        CancellationToken cancellationToken)

    {
        try
        {
            var filter = _mapper.Map<PropertyFilterDto>(request);
            var (properties, totalCount) = await _propertyRepository.GetByFilterAsync(filter);

            return new PaginatedResponse<PropertyDto>
            {
                Items = _mapper.Map<IEnumerable<PropertyDto>>(properties),
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)request.PageSize)
            };
        }
        catch (Exception ex)
        {
            throw new PropertyFilterException("Error getting properties by filter" + " " + ex.Message);
        }
    }
}
