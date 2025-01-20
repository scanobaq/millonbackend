using Application.DTOs.Property;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Properties.Queries.GetPropertyId
{
    public class GetAllPrpertyQueryHandler : IRequestHandler<GetAllPropertyQuery, IEnumerable<PropertyDto>>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public GetAllPrpertyQueryHandler(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PropertyDto>> Handle(GetAllPropertyQuery request, CancellationToken cancellationToken)
        {
            var properties = await _propertyRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PropertyDto>>(properties);
        }
    }
}