using Decision.Api.Features.Decisions.DecisionEngineHandlers;
using Decision.Contract.Constants;
using Decision.Contract.Features;
using FluentAssertions;
using Xunit;

namespace Decision.Api.Tests.Features.DecisionEngineHandlers
{
    public class LegacyDecisionHandlerTester
    {
        private LegacyDecisionEngineHandler _sut;

        public LegacyDecisionHandlerTester()
        {
            _sut = new LegacyDecisionEngineHandler();
        }

        [Fact]
        public void Should_handle_legacy_decision()
        {
            var request = new GetDecisionContract.Request{ DecisionEngineId = DecisionEngineConstants.Legacy };
            _sut.IsHandled(request).Should().BeTrue();
        }

        [Fact]
        public void Should_not_handle_temenos_decision()
        {
            var request = new GetDecisionContract.Request { DecisionEngineId = DecisionEngineConstants.Temenos };
            _sut.IsHandled(request).Should().BeFalse();
        }

        [Fact]
        public void Should_return_legacy_notice_type_approved()
        {
            var request = new GetDecisionContract.Request();
            _sut.Execute(request).Result.NoticeType.Should().Be("APPROVED");
        }
    }
}
