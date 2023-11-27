using System;
using LineService.Application.Features.Webhook.Commands.WebhookEvent;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LineService.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("v1/[controller]")]
    public class LineController : ControllerBase    
	{
        private readonly IMediator _mediator;

        public LineController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("[Action]", Name = "Webhook")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> InsertActivity([FromBody] WebhookEventCommand command)
        {
            var resp = await _mediator.Send(command);
            return Ok(resp);
        }

    }
}

