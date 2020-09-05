using BusinessRuleEngine.RuleEngineFactory.Interfaces;

namespace BusinessRuleEngine.RuleEngineFactory.Services
{
    public class RuleEngineService
    {
        
        private IRuleEngine paymentType = null;

        public RuleEngineService(IRuleEngine paymentType)
        {
            this.paymentType = paymentType;
        }
        public string StartProcess()
        {
            return this.paymentType.ProcessRule();
        }
    }
}