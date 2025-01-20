using Domain.Entities;
using Application.DTOs.Property;

namespace Application.Interfaces.Repositories;

public interface IPropertyRepository
{
    Task<IEnumerable<Property>> GetAllAsync();
    Task<Property> GetByIdAsync(string id);
    Task<Property> CreateAsync(Property property);
    Task UpdateAsync(Property property);
    Task DeleteAsync(string id);
    Task<(IEnumerable<Property> Properties, long TotalCount)> GetByFilterAsync(PropertyFilterDto filter);
}
