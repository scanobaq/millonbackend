
using MongoDB.Driver;
using Domain.Entities;
using Application.Interfaces.Repositories;

namespace Infrastructure.Persistence.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly IMongoCollection<Owner> _collection;

        public OwnerRepository(MongoDbContext context)
        {
            _collection = context.Database.GetCollection<Owner>("Owners");
        }

        public async Task<IEnumerable<Owner>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<Owner> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.OwnerId == Guid.Parse(id)).FirstOrDefaultAsync();
        }

        public async Task<Owner> CreateAsync(Owner owner)
        {
            await _collection.InsertOneAsync(owner);
            return owner;
        }

        public async Task UpdateAsync(Owner owner)
        {
            await _collection.ReplaceOneAsync(
                x => x.OwnerId == owner.OwnerId,
                owner
            );
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.OwnerId == Guid.Parse(id));
        }
    }
}