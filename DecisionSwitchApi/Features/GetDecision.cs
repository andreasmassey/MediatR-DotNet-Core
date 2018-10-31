using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Decision.Contract.Features;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Decision.Api.Features
{
    public class GetDecision
    {
        public class Handler : IRequestHandler<GetDecisionContract.Request, GetDecisionContract.Response>
        {
            private readonly IConfiguration _configuration;

            public Handler(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public async Task<GetDecisionContract.Response> Handle(
                GetDecisionContract.Request request, 
                CancellationToken cancellationToken)
            {
                var decisionEngine = "5"; //TODO: Get from Elizabeth's API
                GetDecisionContract.Response response;

                var decisionIDs = _configuration["AppSettings:DecisionIDs"]?.Split(',');
                if (decisionIDs != null && decisionIDs.Any(x => decisionEngine == x.Trim()))
                {
                    response = new GetDecisionContract.Response //TODO: Call out to API Connect
                    {
                        Message = "Going out to API Connect",
                        NoticeType = "APPROVED",
                        StatusDetails = new List<GetDecisionContract.DecisionInfo>()
                    }; 
                }
                else
                {
                    response = new GetDecisionContract.Response //TODO: Call out to Elizabeth's API
                    {
                        Message = "Going to Decisioning Legacy API",
                        NoticeType = "APPROVED",
                        StatusDetails = new List<GetDecisionContract.DecisionInfo>()
                    };  
                }

                return await Task.FromResult(response);
            }
        }
    }
}
