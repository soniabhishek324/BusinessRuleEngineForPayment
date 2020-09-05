using BusinessRuleEngine.RuleEngineFactory.Constants;

namespace BusinessRuleEngine.RuleEngineFactory.Helpers
{
    public class CommonHelper
    {
        public string SendEmailToOwnerForMembership()
        {
            return RuleEngineMessages.SendEmailToOwner;
        }

        public string CommisionToAgent()
        {
            return RuleEngineMessages.GenerateCommisionToAgent;
        }
    }
}