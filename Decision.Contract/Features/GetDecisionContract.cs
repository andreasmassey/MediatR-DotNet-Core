using System;
using System.Collections.Generic;
using Decision.Contract.Binder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Decision.Contract.Features
{
    public class GetDecisionContract
    {
        public class Progress
        {
            public int ProgressId { get; set; }
            public string TokenId { get; set; }
            public string FolderId { get; set; }
            public string LoanRequestFormId { get; set; }
            public DateTime ValidTokenTimestamp { get; set; }
            public DateTime CreateTimestamp { get; set; }
            public string UpdateUserId { get; set; }
            public DateTime UpdateTimestamp { get; set; }
            public int? ElapsedTime { get; set; }
            public string CreditUnionId { get; set; }
            public string LocationId { get; set; }
            public string ChannelId { get; set; }
            public string LoanListId { get; set; }
            public string DeviceToken { get; set; }
            public bool? IsFramed { get; set; }
        }

        public class GetFormFamilyDTO
        {
            public List<LoanRequestFormLoanFormDTO> LoanFormDTOs { get; set; }
        }

        public class LoanRequestFormLoanFormDTO
        {
            public string LoanFormID { get; set; }

            public string LoanRequestFormConfigurationID { get; set; }

            public string LendingFormID { get; set; }

            public string ExternalDecisionModelID { get; set; }

            public string ExternalDecisionMatrixID { get; set; }

            public string ExternalDocsetTemplateID { get; set; }

            public string ExternalProtectionPackageID { get; set; }

            public string ExternalRelationshipPriceID { get; set; }

            public int ExternalReferralProductID { get; set; }

            public bool ResumeAllowed { get; set; }

            public string FormURL { get; set; }

            public string ReturnURL { get; set; }

            public string StatusCode { get; set; }

            public string SecurityCode { get; set; }

            public string TemplateCode { get; set; }

            public int RepeatPageAmount { get; set; }

            public int TotalPageAmount { get; set; }

            public bool ApplyDecisionModel { get; set; }

            public bool UseInterestRateMatrix { get; set; }

            public double? OutstandingBalancePercent { get; set; }

            public double? DecisionInterestRate { get; set; }

            public bool IncludeLPLanguage { get; set; }

            public bool OverridePageBreak { get; set; }

            public int MaximumNumberApplicants { get; set; }

            public string DefaultStateCode { get; set; }

            public bool ShowCreditCardDisclosures { get; set; }

            public string HomeEquityProgramCode { get; set; }

            public bool IsPrefillEnabled { get; set; }

            public string LPDecisionCode { get; set; }

            public bool RequestLPDecisionsOnDenied { get; set; }

            public bool ShowHomeEquityDisclosure { get; set; }

            public bool IsSecuredLoan { get; set; }

            public bool IsFormClassic { get; set; }

            public bool IsUsabilityFeedbackEnabled { get; set; }

           public bool EnableContactCenterTransfer { get; set; }

            public bool IncludeCalculator { get; set; }

            public string DisclosureSourceCode { get; set; }

            public bool CollectSpousalInformation { get; set; }

            public int ExternalFeaturedLoanProgramID { get; set; }

            public int ExternalLendingFormFlowID { get; set; }

            public int ExternalLendingSubtypeID { get; set; }

            public string LoanOriginatorOrganization { get; set; }

            public string OrganizationNmlsId { get; set; }

            public string LoanOriginator { get; set; }

            public string OriginatorNmlsId { get; set; }
        }

        public class LoanFormDecisioning
        {
            //public Progress Progress { get; set; }

            //public GetFormFamilyDTO GetFormFamilyDto { get; set; }

            //public LoanRequestFormLoanFormDTO LoanRequestFormDto { get; set; }

            public string TokenId { get; set; }
        }

        [ModelBinder(typeof(DecisionRequestBinder))]
        public class Request : IRequest, IRequest<Response>
        {
            public Progress Progress { get; set; }
            public GetFormFamilyDTO GetFormFamilyDto { get; set; }
            public LoanRequestFormLoanFormDTO LoanRequestFormLoanFormDTO { get; set; }
            public LoanFormDecisioning LoanFormDecisioning { get; set; }
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
