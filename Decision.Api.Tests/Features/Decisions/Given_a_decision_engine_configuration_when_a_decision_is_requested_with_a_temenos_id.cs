using System.Collections.Generic;
using System.Threading;
using Decision.Api.Features.Decisions;
using Decision.Api.Features.Decisions.DecisionEngineHandlers;
using Decision.Contract.Constants;
using Decision.Contract.Features;
using FluentAssertions;
using Xunit;

namespace Decision.Api.Tests.Features.Decisions
{
    public class Given_a_decision_engine_configuration_when_a_decision_is_requested_with_a_temenos_id : TestClassBase
    {
        private readonly GetDecisionContract.Response _response;

        public Given_a_decision_engine_configuration_when_a_decision_is_requested_with_a_temenos_id()
        {
            var decisionHandlers = new List<IDecisionEngineHandler>
            {
                new LegacyDecisionEngineHandler(),
                new TemenosDecisionEngineHandler()
            };

            var handler = new GetDecision.Handler(decisionHandlers);
            _response = handler.Handle(new GetDecisionContract.Request{ DecisionEngineId = DecisionEngineConstants.Temenos }, new CancellationToken()).Result;
        }

        [Fact]
        public void Then_response_message_should_be_api_connect()
        {
            _response.Message.Should().Be("Going out to API Connect");
        }

        [Fact]
        public void Then_response_notice_type_should_be_approved()
        {
            _response.NoticeType.Should().Be("APPROVED");
        }
    }
}
