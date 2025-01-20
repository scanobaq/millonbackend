using MongoDB.Bson.Serialization;
using Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
public static class MongoDbConfigurator
{
    public static void Configure()
    {


        BsonClassMap.RegisterClassMap<Owner>(cm =>
        {
            cm.AutoMap();
            cm.MapIdMember(x => x.OwnerId)
              .SetIdGenerator(GuidGenerator.Instance)
              .SetSerializer(new MongoDB.Bson.Serialization.Serializers.GuidSerializer(MongoDB.Bson.GuidRepresentation.CSharpLegacy));
            cm.MapMember(x => x.Name).SetElementName("name");
            cm.MapMember(x => x.Address).SetElementName("address");
            cm.MapMember(x => x.Photo).SetElementName("photo");
        });

        BsonClassMap.RegisterClassMap<Property>(cm =>
        {
            cm.AutoMap();
            cm.MapIdMember(x => x.PropertyId)
                .SetIdGenerator(GuidGenerator.Instance)
                .SetSerializer(new MongoDB.Bson.Serialization.Serializers.GuidSerializer(MongoDB.Bson.GuidRepresentation.CSharpLegacy));
            cm.MapMember(x => x.Name).SetElementName("name");
            cm.MapMember(x => x.Address).SetElementName("address");
            cm.MapMember(x => x.Price).SetElementName("price");
            cm.MapMember(x => x.CodeInternal).SetElementName("codeInternal");
            cm.MapMember(x => x.Year).SetElementName("year");
            cm.MapMember(x => x.OwnerId).SetElementName("idOwner");

        });


        // var collection = database.GetCollection<Property>("properties");
        // var indexKeysDefinition = Builders<Property>.IndexKeys
        // .Ascending(x => x.Name)
        // .Ascending(x => x.Address)
        // .Ascending(x => x.Price);

        // var indexOptions = new CreateIndexOptions
        // {
        //     Name = "PropertySearch",
        //     Background = true,
        // };

        // var indexModel = new CreateIndexModel<Property>(indexKeysDefinition, indexOptions);
        // collection.Indexes.CreateOne(indexModel);

        // // Índice de texto para búsqueda full-text
        // var textIndexKeysDefinition = Builders<Property>.IndexKeys
        //     .Text(p => p.Name)
        //     .Text(p => p.Address);

        // var textIndexOptions = new CreateIndexOptions
        // {
        //     Name = "PropertyTextSearch"
        // };

        // var textIndexModel = new CreateIndexModel<Property>(textIndexKeysDefinition, textIndexOptions);
        // collection.Indexes.CreateOne(textIndexModel);
    }
}