using System.Collections.Generic;
using System.Threading.Tasks;
using Decision.Contract.Constants;
using Decision.Contract.Features;

namespace Decision.Api.Features.Decisions.DecisionEngineHandlers
{
    public class TemenosDecisionEngineHandler : IDecisionEngineHandler
    {
        public Task<GetDecisionContract.Response> Execute(GetDecisionContract.Request request)
        {
            var response = new GetDecisionContract.Response //TODO: Call out to API Connect
            {
                Message = "Going out to API Connect",
                NoticeType = "APPROVED",
                StatusDetails = new List<GetDecisionContract.DecisionInfo>()
            };

            return Task.Factory.StartNew(() => response);
        }

        public bool IsHandled(GetDecisionContract.Request request)
        {
            if (request.DecisionEngineId == DecisionEngineConstants.Temenos)
                return true;
            return false;
        }
    }
}