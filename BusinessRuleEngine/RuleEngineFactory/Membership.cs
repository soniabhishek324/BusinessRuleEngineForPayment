using BusinessRuleEngine.RuleEngineFactory.Constants;
using BusinessRuleEngine.RuleEngineFactory.Helpers;
using BusinessRuleEngine.RuleEngineFactory.Interfaces;
using System.Text;

namespace BusinessRuleEngine.RuleEngineFactory
{
    // If the Payment is for Membership, Activate that membership.
    // If the payment is for Membership or upgrade membership, email the owner and inform them of the activation/upgrade.
    public class Membership : IRuleEngine
    {
        private CommonHelper _helper { get; set; } = new CommonHelper();
        public string ProcessRule()
        {
            StringBuilder str = new StringBuilder();
            str.Append(RuleEngineMessages.ActivateMemberShip);
            str.Append(RuleEngineMessages.AND);
            str.Append(this._helper.SendEmailToOwnerForMembership());
            return str.ToString();
        }
    }
}