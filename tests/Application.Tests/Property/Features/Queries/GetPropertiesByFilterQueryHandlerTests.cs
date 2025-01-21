using Application.Common.Wrappers;
using Application.DTOs.Property;
using Application.Features.Properties.Queries.GetPropertyFilter;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Application.Tests.Features.Properties.Queries;

[TestFixture]
public class GetPropertiesByFilterQueryHandlerTests
{
    private Mock<IPropertyRepository> _propertyRepositoryMock;
    private Mock<IMapper> _mapperMock;
    private GetPropertiesByFilterQueryHandler _handler;

    [SetUp]
    public void Setup()
    {
        _propertyRepositoryMock = new Mock<IPropertyRepository>();
        _mapperMock = new Mock<IMapper>();
        _handler = new GetPropertiesByFilterQueryHandler(
            _propertyRepositoryMock.Object,
            _mapperMock.Object
        );
    }

    [Test]
    public async Task Handle_ShouldReturnPaginatedResponse_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetPropertiesByFilterQuery
        {
            PageNumber = 1,
            PageSize = 10,
            Name = "Test Property"
        };

        var properties = new List<Property>
        {
            new Property
            {
                OwnerId = "1",
                Name = "Test Property",
                Address = "Test Address",
                Price = 100000,
                Year = "2020"
            }
        };

        var propertyDtos = new List<PropertyDto>
        {
            new PropertyDto
            {
                OwnerId = "1",
                Name = "Test Property",
                Address = "Test Address",
                Price = 100000,
                Year = "2020"
            }
        };

        _propertyRepositoryMock
            .Setup(x => x.GetByFilterAsync(
                It.IsAny<PropertyFilterDto>()))
            .ReturnsAsync((properties, 1));

        _mapperMock
            .Setup(x => x.Map<IEnumerable<PropertyDto>>(It.IsAny<IEnumerable<Property>>()))
            .Returns(propertyDtos);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        Console.WriteLine(result);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<PaginatedResponse<PropertyDto>>();
        result.Items.Should().HaveCount(1);
        result.PageNumber.Should().Be(1);
        result.PageSize.Should().Be(10);
        result.TotalCount.Should().Be(1);

        _propertyRepositoryMock.Verify(
            x => x.GetByFilterAsync(It.IsAny<PropertyFilterDto>()),
            Times.Once);

        _mapperMock.Verify(
            x => x.Map<IEnumerable<PropertyDto>>(It.IsAny<IEnumerable<Property>>()),
            Times.Once);
    }

    [Test]
    public async Task Handle_ShouldReturnEmptyResponse_WhenNoPropertiesFound()
    {
        // Arrange
        var query = new GetPropertiesByFilterQuery
        {
            PageNumber = 1,
            PageSize = 10,
            Name = "Nonexistent Property"
        };

        _propertyRepositoryMock
            .Setup(x => x.GetByFilterAsync(It.IsAny<PropertyFilterDto>()))
            .ReturnsAsync((new List<Property>(), 0));

        _mapperMock
            .Setup(x => x.Map<IEnumerable<PropertyDto>>(It.IsAny<IEnumerable<Property>>()))
            .Returns(new List<PropertyDto>());

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Items.Should().BeEmpty();
        result.TotalCount.Should().Be(0);
    }
}