using BusinessRuleEngine.RuleEngineFactory.Constants;
using BusinessRuleEngine.RuleEngineFactory.Helpers;
using BusinessRuleEngine.RuleEngineFactory.Interfaces;
using System.Text;

namespace BusinessRuleEngine.RuleEngineFactory
{
    public class MembershipUpgrade : IRuleEngine
    {
        private CommonHelper _helper { get; set; } = new CommonHelper();
        public string ProcessRule()
        {
            StringBuilder str = new StringBuilder();
            str.Append(RuleEngineMessages.UpgradeMemberShip);
            str.Append(RuleEngineMessages.AND);
            str.Append(this._helper.SendEmailToOwnerForMembership());
            return str.ToString();
        }
    }
}