
using Application.DTOs.Property;
using MediatR;

namespace Application.Features.Properties.Queries.GetPropertyId;

public class GetAllPropertyQuery : IRequest<IEnumerable<PropertyDto>>
{

}
