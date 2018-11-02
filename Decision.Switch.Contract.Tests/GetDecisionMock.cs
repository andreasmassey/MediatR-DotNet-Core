using System.Collections.Generic;
using System.Net;
using Decision.Contract.Features;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace Decision.Service.Contract.MockServer
{
    public class GetDecisionMock
    {
        public FluentMockServer Server;

        public void GetMockServer(string url, string path, GetDecisionContract.Request request, HttpStatusCode status)
        {
            Server = FluentMockServer.Start(
                new FluentMockServerSettings{ Urls = new [] {url}, StartAdminInterface = true});

            GetDecisionContract.Response response;

            if(status == HttpStatusCode.OK)
                response = new GetDecisionContract.Response
                {
                    Message = "Message from response",
                    NoticeType = "ACCEPTED",
                    StatusDetails = new List<GetDecisionContract.DecisionInfo>
                    {
                        new GetDecisionContract.DecisionInfo
                        {
                            DecisionStatus = "status",
                            DecisionStatusURL = "url",
                            InterestRate = 22.22,
                            LoanAmount = 1234.32,
                            Order = new GetDecisionContract.DecisionOrder(),
                            Origination = "origination",
                            Term = 3
                        }
                    }
                };
            else
                response = new GetDecisionContract.Response
                {
                    Message = "Failed to make call",
                    NoticeType = "DECLINED",
                    StatusDetails = new List<GetDecisionContract.DecisionInfo>
                    {
                        new GetDecisionContract.DecisionInfo
                        {
                            DecisionStatus = "status",
                            DecisionStatusURL = "url",
                            InterestRate = 22.22,
                            LoanAmount = 1234.32,
                            Order = new GetDecisionContract.DecisionOrder(),
                            Origination = "origination",
                            Term = 3
                        }
                    }
                };
            Server.Given(Request.Create().UsingPost().WithPath(path))
                .RespondWith(Response.Create().WithBodyAsJson(response));
        }

        public void StopServer()
        {
            this.Server.Stop();
        }
    }
}
