using Application.Interfaces.Repositories;
using Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using Application.DTOs.Property;

namespace Infrastructure.Persistence.Repositories;

public class PropertyRepository : IPropertyRepository
{
    private readonly IMongoCollection<Property> _collection;

    public PropertyRepository(MongoDbContext context)
    {
        _collection = context.Database.GetCollection<Property>("Properties");
    }

    public async Task<IEnumerable<Property>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<Property> GetByIdAsync(string id)
    {
        return await _collection.Find(x => x.PropertyId == Guid.Parse(id)).FirstOrDefaultAsync();
    }

    public async Task<Property> CreateAsync(Property property)
    {
        await _collection.InsertOneAsync(property);
        return property;
    }

    public async Task UpdateAsync(Property property)
    {
        await _collection.ReplaceOneAsync(x => x.PropertyId == property.PropertyId, property);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.PropertyId == Guid.Parse(id));
    }

    public async Task<(IEnumerable<Property> Properties, long TotalCount)> GetByFilterAsync(PropertyFilterDto filter)
    {
        var builder = Builders<Property>.Filter;
        var filterDefinitions = new List<FilterDefinition<Property>>();

        if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
        {
            filterDefinitions.Add(builder.Text(filter.SearchTerm));
        }
        else
        {
            if (!string.IsNullOrWhiteSpace(filter.Name))
                filterDefinitions.Add(builder.Regex(x => x.Name, new BsonRegularExpression(filter.Name, "i")));

            if (!string.IsNullOrWhiteSpace(filter.Address))
                filterDefinitions.Add(builder.Regex(x => x.Address, new BsonRegularExpression(filter.Address, "i")));
        }

        if (filter.MinPrice.HasValue)
            filterDefinitions.Add(builder.Gte(x => x.Price, filter.MinPrice.Value));

        if (filter.MaxPrice.HasValue)
            filterDefinitions.Add(builder.Lte(x => x.Price, filter.MaxPrice.Value));

        var finalFilter = filterDefinitions.Any()
            ? builder.And(filterDefinitions)
            : builder.Empty;

        var sort = GetSortDefinition(filter.SortBy, filter.IsDescending);

        var propertiesTask = _collection
            .Find(finalFilter)
            .Sort(sort)
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Limit(filter.PageSize)
            .ToListAsync();

        var countTask = _collection.CountDocumentsAsync(finalFilter);

        await Task.WhenAll(propertiesTask, countTask);

        return (await propertiesTask, await countTask);
    }

    private SortDefinition<Property> GetSortDefinition(string? sortBy, bool isDescending)
    {
        var sort = Builders<Property>.Sort;

        return sortBy?.ToLower() switch
        {
            "price" => isDescending ? sort.Descending(p => p.Price) : sort.Ascending(p => p.Price),
            "name" => isDescending ? sort.Descending(p => p.Name) : sort.Ascending(p => p.Name),
            _ => sort.Ascending(p => p.Name)
        };
    }
}

