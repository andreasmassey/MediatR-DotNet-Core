using Decision.Api.Features.Decisions.DecisionEngineHandlers;
using Decision.Contract.Constants;
using Decision.Contract.Features;
using FluentAssertions;
using Xunit;

namespace Decision.Api.Tests.Features.DecisionEngineHandlers
{
    public class TemenosDecisionHandlerTester
    {
        private readonly TemenosDecisionEngineHandler _sut;
        public TemenosDecisionHandlerTester()
        {
            _sut = new TemenosDecisionEngineHandler();
        }

        [Fact]
        public void Should_handle_temenos_decision()
        {
            var request = new GetDecisionContract.Request { DecisionEngineId = DecisionEngineConstants.Temenos };
            _sut.IsHandled(request).Should().BeTrue();
        }

        [Fact]
        public void Should_not_handle_legacy_decision()
        {
            var request = new GetDecisionContract.Request{ DecisionEngineId = "5"};
            _sut.IsHandled(request).Should().BeFalse();
        }

        [Fact]
        public void Should_return_temenos_message()
        {
            var request = new GetDecisionContract.Request();
            _sut.Execute(request).Result.Message.Should().Be("Going out to API Connect");
        }

        [Fact]
        public void Should_return_temenos_notice_type_approved()
        {
            var request = new GetDecisionContract.Request();
            _sut.Execute(request).Result.NoticeType.Should().Be("APPROVED");
        }
    }
}
