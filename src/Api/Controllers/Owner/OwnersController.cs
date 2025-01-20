using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.DTOs.Owner;
using Application.Features.Owners.Commands.CreateOwner;
using Application.Features.Owners.Queries.GetOwnerById;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OwnersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<OwnerDto>>> GetAll()
        // {
        //     var query = new GetAllOwnersQuery();
        //     var result = await _mediator.Send(query);
        //     return Ok(result);
        // }

        [HttpGet("{id}")]
        public async Task<ActionResult<OwnerDto>> GetById(string id)
        {
            var query = new GetOwnerByIdQuery(id);
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<OwnerDto>> Create([FromBody] CreateOwnerCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.OwnerId }, result);
        }

        // [HttpPut("{id}")]
        // public async Task<ActionResult<OwnerDto>> Update(int id, [FromBody] UpdateOwnerCommand command)
        // {
        //     command.Id = id;
        //     var result = await _mediator.Send(command);
        //     return Ok(result);
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     await _mediator.Send(new DeleteOwnerCommand { Id = id });
        //     return NoContent();
        // }
    }
}