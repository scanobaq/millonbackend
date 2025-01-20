using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IOwnerRepository
{
    Task<IEnumerable<Owner>> GetAllAsync();
    Task<Owner> GetByIdAsync(string id);
    Task<Owner> CreateAsync(Owner owner);
    Task UpdateAsync(Owner owner);
    Task DeleteAsync(string id);
}