using System;
using System.Net;
using LineService.Application.Features.Message.Commands.PushMessage;
using LineService.Application.Features.Webhook.Commands.WebhookEvent;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LineService.Api.Controllers
{    
    [ApiController]
    [Route("v1/[controller]")]
    public class LineController : ControllerBase    
	{
        private readonly IMediator _mediator;

        public LineController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("[Action]")]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Unit>> Webhook(WebhookEventCommand param)
        {
            try
            {
                var resp = await _mediator.Send(param);
                return Ok(resp);
            }
            catch (System.Exception ex)
            {
                var a = ex.ToString();
            }
            
            return Ok();
        }

        [HttpPost("[Action]")]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Unit>> PushMessage(PushMessageCommand param)
        {
            try
            {
                var resp = await _mediator.Send(param);
                return Ok(resp);
            }
            catch (System.Exception ex)
            {
                var a = ex.ToString();
            }

            return Ok();
        }

        //[HttpPost("[Action]", Name = "Webhook")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesDefaultResponseType]
        //public async Task<ActionResult> Webhook([FromBody] object command)
        //{
        //    var s = JsonConvert.SerializeObject(command);

        //    //var resp = await _mediator.Send(command);
        //    return Ok();
        //}

    }
}

