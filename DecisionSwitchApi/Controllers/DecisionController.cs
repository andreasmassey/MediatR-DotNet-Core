using System.Threading.Tasks;
using Decision.Contract.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Decision.Api.Controllers
{
    [Route("api/decision")]
    [ApiController]
    public class DecisionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DecisionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(GetDecisionContract))]
        [Route("v1/getdecision")]
        public async Task<ActionResult<GetDecisionContract.Response>> GetDecisionAsync([FromBody] GetDecisionContract.Request request)
        {
            return await _mediator.Send<GetDecisionContract.Response>(request);
        }
    }
}