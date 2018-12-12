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

            public async Task<GetDecisionContract.Response> Handle(GetDecisionContract.Request request, CancellationToken cancellationToken)
            {
                var response = await _handlers.Single(x => x.IsHandled(request)).Execute(request, cancellationToken);
                var contract = new GetDecisionContract.Response
                {
                    Message = response.Message,
                    StatusDetails = response.StatusDetails,
                    NoticeType = response.NoticeType
                };
                return contract;
            }
        }
    }
}
