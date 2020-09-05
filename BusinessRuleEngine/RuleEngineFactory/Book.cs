using BusinessRuleEngine.RuleEngineFactory.Constants;
using BusinessRuleEngine.RuleEngineFactory.Helpers;
using BusinessRuleEngine.RuleEngineFactory.Interfaces;
using System.Text;

namespace BusinessRuleEngine.RuleEngineFactory
{
    public class Book : IRuleEngine
    {
        private CommonHelper _helper { get; set; } = new CommonHelper();
        public string ProcessRule()
        {
            StringBuilder str = new StringBuilder();
            str.Append(RuleEngineMessages.DuplicatePackingSlip);
            str.Append(RuleEngineMessages.AND);
            str.Append(this._helper.CommisionToAgent());
            return str.ToString();
        }
    }
}