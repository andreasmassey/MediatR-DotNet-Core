using System.Collections.Generic;
using Decision.Contract.Binder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Decision.Contract.Features
{
    public class GetDecisionContract
    {
        [ModelBinder(typeof(DecisionRequestBinder))]
        public class Request : IRequest, IRequest<Response>
        {
            public string DecisionEngineId { get; set; }
        }

        public class Response
        {
            public string Message { get; set; }
            public string NoticeType { get; set; }
            public List<DecisionInfo> StatusDetails { get; set; }
        }

        public class DecisionInfo
        {
            public string DecisionStatus { get; set; }
            public string DecisionStatusURL { get; set; }
            public string Origination { get; set; }
            public double? LoanAmount { get; set; }
            public int? Term { get; set; }
            public double? InterestRate { get; set; }
            public DecisionOrder Order { get; set; }
        }

        public enum DecisionOrder
        {
            ORIGINAL = 5,
            COUNTEROFFER = 10,
            PENDING_OFFER = 15,
            UPSALE = 20,
            LENDPRO = 25
        }
    }
}
