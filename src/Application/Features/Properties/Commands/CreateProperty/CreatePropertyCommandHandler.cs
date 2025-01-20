using Application.DTOs.Property;
using Application.Interfaces.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions.Property;
using MediatR;

namespace Application.Features.Properties.Commands.CreateProperty;

public class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, PropertyDto>
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly IMapper _mapper;
    private readonly IImageService _imageService;

    public CreatePropertyCommandHandler(IPropertyRepository propertyRepository, IMapper mapper, IImageService imageService)
    {
        _propertyRepository = propertyRepository;
        _imageService = imageService;
        _mapper = mapper;
    }

    public async Task<PropertyDto> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var imagePath = await _imageService.SaveImageAsync(request.ImageFile);
            var property = _mapper.Map<Property>(request);
            property.PropertyImagePath = imagePath;
            var createdProperty = await _propertyRepository.CreateAsync(property);
            return _mapper.Map<PropertyDto>(createdProperty);
        }
        catch (Exception ex)
        {
            throw new PropertyCreateException("Error creating property" + " " + ex.Message);
        }
    }
}

