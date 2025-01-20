// Infrastructure/Persistence/SeedDb/DbInitializer.cs
using Domain.Entities;
using MongoDB.Driver;

public static class DbInitializer
{
    public static async Task SeedData(IMongoDatabase database)
    {
        var owners = database.GetCollection<Owner>("Owners");
        var properties = database.GetCollection<Property>("Properties");

        // Verificar si ya existen datos
        if (!await owners.Find(_ => true).AnyAsync())
        {
            // Crear owners de ejemplo
            var owner1Id = Guid.NewGuid();
            var owner2Id = Guid.NewGuid();

            var seedOwners = new List<Owner>
            {
                new Owner
                {
                    OwnerId = owner1Id,
                    Name = "John Doe",
                    Address = "123 Main St",
                    Photo = "https://randomuser.me/api/portraits/men/1.jpg"
                },
                new Owner
                {
                    OwnerId = owner2Id,
                    Name = "Jane Smith",
                    Address = "456 Oak Ave",
                    Photo = "https://randomuser.me/api/portraits/women/1.jpg"
                }
            };

            await owners.InsertManyAsync(seedOwners);

            // Crear properties de ejemplo
            var seedProperties = new List<Property>
            {
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "Luxury Beach House",
                    Address = "789 Ocean Dr",
                    Price = 1500000,
                    CodeInternal = "BH001",
                    Year = "2020",
                    OwnerId = owner1Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=1"
                },
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "Downtown Apartment",
                    Address = "321 City Center",
                    Price = 500000,
                    CodeInternal = "AP001",
                    Year = "2019",
                    OwnerId = owner2Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=2"
                },
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "Mountain Cabin",
                    Address = "555 Pine Ridge",
                    Price = 750000,
                    CodeInternal = "MC001",
                    Year = "2021",
                    OwnerId = owner1Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=3"
                },
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "Cozy Cottage",
                    Address = "101 Maple St",
                    Price = 300000,
                    CodeInternal = "CC001",
                    Year = "2018",
                    OwnerId = owner2Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=4"
                },
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "Urban Loft",
                    Address = "202 Elm St",
                    Price = 450000,
                    CodeInternal = "UL001",
                    Year = "2017",
                    OwnerId = owner1Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=5"
                },
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "Country House",
                    Address = "303 Birch Rd",
                    Price = 600000,
                    CodeInternal = "CH001",
                    Year = "2016",
                    OwnerId = owner2Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=6"
                },
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "Modern Villa",
                    Address = "404 Cedar Ave",
                    Price = 1200000,
                    CodeInternal = "MV001",
                    Year = "2022",
                    OwnerId = owner1Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=7"
                },
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "Suburban Home",
                    Address = "505 Spruce St",
                    Price = 550000,
                    CodeInternal = "SH001",
                    Year = "2015",
                    OwnerId = owner2Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=8"
                },
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "Penthouse Suite",
                    Address = "606 Oak St",
                    Price = 2000000,
                    CodeInternal = "PS001",
                    Year = "2023",
                    OwnerId = owner1Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=9"
                },
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "Beachfront Condo",
                    Address = "707 Palm Dr",
                    Price = 800000,
                    CodeInternal = "BC001",
                    Year = "2021",
                    OwnerId = owner2Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=10"
                },
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "Historic Mansion",
                    Address = "808 Walnut St",
                    Price = 2500000,
                    CodeInternal = "HM001",
                    Year = "2014",
                    OwnerId = owner1Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=11"
                },
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "Lake House",
                    Address = "909 Lakeview Dr",
                    Price = 950000,
                    CodeInternal = "LH001",
                    Year = "2020",
                    OwnerId = owner2Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=12"
                },
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "City Studio",
                    Address = "1010 Market St",
                    Price = 400000,
                    CodeInternal = "CS001",
                    Year = "2019",
                    OwnerId = owner1Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=13"
                },
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "Farmhouse",
                    Address = "1111 Country Ln",
                    Price = 700000,
                    CodeInternal = "FH001",
                    Year = "2018",
                    OwnerId = owner2Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=14"
                },
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "Luxury Penthouse",
                    Address = "1212 Skyline Blvd",
                    Price = 3000000,
                    CodeInternal = "LP001",
                    Year = "2023",
                    OwnerId = owner1Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=15"
                },
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "Rustic Barn",
                    Address = "1313 Farm Rd",
                    Price = 250000,
                    CodeInternal = "RB001",
                    Year = "2017",
                    OwnerId = owner2Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=16"
                },
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "Seaside Villa",
                    Address = "1414 Ocean Blvd",
                    Price = 1800000,
                    CodeInternal = "SV001",
                    Year = "2022",
                    OwnerId = owner1Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=17"
                },
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "Downtown Condo",
                    Address = "1515 Central Ave",
                    Price = 650000,
                    CodeInternal = "DC001",
                    Year = "2016",
                    OwnerId = owner2Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=18"
                },
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "Mountain Retreat",
                    Address = "1616 Highland Rd",
                    Price = 900000,
                    CodeInternal = "MR001",
                    Year = "2021",
                    OwnerId = owner1Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=19"
                },
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "Urban Flat",
                    Address = "1717 City St",
                    Price = 500000,
                    CodeInternal = "UF001",
                    Year = "2015",
                    OwnerId = owner2Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=20"
                },
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "Countryside Villa",
                    Address = "1818 Meadow Ln",
                    Price = 1100000,
                    CodeInternal = "CV001",
                    Year = "2020",
                    OwnerId = owner1Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=21"
                },
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "Modern Apartment",
                    Address = "1919 Urban Blvd",
                    Price = 600000,
                    CodeInternal = "MA001",
                    Year = "2019",
                    OwnerId = owner2Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=22"
                },
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "Beach House",
                    Address = "2020 Shoreline Dr",
                    Price = 1300000,
                    CodeInternal = "BH002",
                    Year = "2021",
                    OwnerId = owner1Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=23"
                },
                new Property
                {
                    PropertyId = Guid.NewGuid(),
                    Name = "Suburban Villa",
                    Address = "2121 Suburbia St",
                    Price = 750000,
                    CodeInternal = "SV002",
                    Year = "2018",
                    OwnerId = owner2Id.ToString(),
                    PropertyImagePath = "https://picsum.photos/800/600?random=24"
                },

            };

            await properties.InsertManyAsync(seedProperties);
        }
    }
}