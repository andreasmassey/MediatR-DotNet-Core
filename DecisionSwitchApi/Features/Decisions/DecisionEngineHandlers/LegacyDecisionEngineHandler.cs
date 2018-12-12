using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Decision.Contract.Constants;
using Decision.Contract.Features;

namespace Decision.Api.Features.Decisions.DecisionEngineHandlers
{
    public class LegacyDecisionEngineHandler : IDecisionEngineHandler
    {
        public Task<GetDecisionContract.Response> Execute(GetDecisionContract.Request request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = new GetDecisionContract.Response
            {
                Message = "Going to Decisioning Legacy API",
                NoticeType = "APPROVED",
                StatusDetails = new List<GetDecisionContract.DecisionInfo>()
            };

            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(response);
        }

        public bool IsHandled(GetDecisionContract.Request request)
        {
            if (request.DecisionEngineId == DecisionEngineConstants.Legacy)
                return true;
            return false;
        }
    }
}