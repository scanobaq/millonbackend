using Application.Common.Wrappers;
using Application.DTOs.Property;
using MediatR;

namespace Application.Features.Properties.Queries.GetPropertyFilter;

public class GetPropertiesByFilterQuery : IRequest<PaginatedResponse<PropertyDto>>
{
    public string SearchTerm { get; set; }  // Para búsqueda de texto
    public string Name { get; set; }
    public string Address { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string SortBy { get; set; }
    public bool IsDescending { get; set; }
}
