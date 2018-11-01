using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Decision.Api.Features.Decisions.DecisionEngineHandlers;
using Decision.Contract.Features;
using MediatR;

namespace Decision.Api.Features.Decisions
{
    public class GetDecision
    {
        public class Handler : IRequestHandler<GetDecisionContract.Request, GetDecisionContract.Response>
        {
            private readonly IEnumerable<IDecisionEngineHandler> _handlers;

            public Handler(IEnumerable<IDecisionEngineHandler> handlers)
            {
                _handlers = handlers;
            }

            public Task<GetDecisionContract.Response> Handle(GetDecisionContract.Request request, CancellationToken cancellationToken)
            {
                var response =_handlers.Single(x => x.IsHandled(request)).Execute(request);
                return response;
            }
        }
    }
}
