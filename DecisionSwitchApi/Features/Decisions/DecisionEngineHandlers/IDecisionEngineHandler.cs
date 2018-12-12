using System.Threading;
using System.Threading.Tasks;
using Decision.Contract.Features;

namespace Decision.Api.Features.Decisions.DecisionEngineHandlers
{
    public interface IDecisionEngineHandler
    {
        bool IsHandled(GetDecisionContract.Request request);
        Task<GetDecisionContract.Response> Execute(GetDecisionContract.Request request, CancellationToken cancellationToken);
    }
}