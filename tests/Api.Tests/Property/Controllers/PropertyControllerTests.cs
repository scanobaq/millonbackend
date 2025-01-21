using Api.Controllers.Property;
using Application.Common.Wrappers;
using Application.DTOs.Property;
using Application.Features.Properties.Queries.GetPropertyFilter;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Api.Tests.Controllers.Property;

[TestFixture]
public class PropertyControllerTests
{
    private Mock<IMediator> _mediatorMock;
    private PropertyController _controller;

    [SetUp]
    public void Setup()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new PropertyController(_mediatorMock.Object);
    }

    [Test]
    public async Task GetByFilter_ShouldReturnOkResult_WithPaginatedResponse()
    {
        // Arrange
        var query = new GetPropertiesByFilterQuery();
        var expectedResponse = new PaginatedResponse<PropertyDto>
        {
            Items = new List<PropertyDto>(),
            PageNumber = 1,
            PageSize = 10,
            TotalCount = 0
        };

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetPropertiesByFilterQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await _controller.GetByFilter(query);

        // Assert
        result.Should().NotBeNull();
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        var returnValue = okResult.Value.Should().BeOfType<PaginatedResponse<PropertyDto>>().Subject;

        returnValue.Should().BeEquivalentTo(expectedResponse);
        _mediatorMock.Verify(x => x.Send(It.IsAny<GetPropertiesByFilterQuery>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}