using BusinessRuleEngine.RuleEngineFactory.Constants;
using BusinessRuleEngine.RuleEngineFactory.Helpers;
using BusinessRuleEngine.RuleEngineFactory.Interfaces;
using System.Text;

namespace BusinessRuleEngine.RuleEngineFactory
{
    // If the Payment is for Physical Product , Generate a packing slip for shipping.
    // If the Payment is for physical product or book, generate a commission payment to agent.
    public class PhysicalProduct : IRuleEngine
    {
        private CommonHelper _helper { get; set; } = new CommonHelper();
        public string ProcessRule()
        {
            StringBuilder str = new StringBuilder();
            str.Append(RuleEngineMessages.GeneratePackingSlip);
            str.Append(RuleEngineMessages.AND);
            str.Append(this._helper.CommisionToAgent());
            return str.ToString();
        }
    }
}