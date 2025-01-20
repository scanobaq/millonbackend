
using Application.Common.Wrappers;
using Application.DTOs.Property;
using Application.Features.Properties.Commands.CreateProperty;
using Application.Features.Properties.Queries.GetPropertyFilter;
using Application.Features.Properties.Queries.GetPropertyId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Property;

[ApiController]
[Route("api/[controller]")]
public class PropertyController : ControllerBase
{
    private readonly IMediator _mediator;

    public PropertyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PropertyDto>>> GetAll()
    {
        var query = new GetAllPropertyQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("filter")]
    public async Task<ActionResult<PaginatedResponse<PropertyDto>>> GetByFilter(
        [FromQuery] GetPropertiesByFilterQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<PropertyDto>> Create([FromForm] CreatePropertyCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

}
