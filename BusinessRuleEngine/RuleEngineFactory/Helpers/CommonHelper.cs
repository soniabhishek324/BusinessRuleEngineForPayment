using BusinessRuleEngine.RuleEngineFactory.Constants;

namespace BusinessRuleEngine.RuleEngineFactory.Helpers
{
    public class CommonHelper
    {
        /// <summary>
        /// This method is used to send email notification for the Owners of Membership.
        /// </summary>
        /// <returns></returns>
        public string SendEmailToOwnerForMembership()
        {
            return RuleEngineMessages.SendEmailToOwner;
        }

        /// <summary>
        /// This methos is used to give commision to agents.
        /// </summary>
        /// <returns></returns>
        public string CommisionToAgent()
        {
            return RuleEngineMessages.GenerateCommisionToAgent;
        }
    }
}