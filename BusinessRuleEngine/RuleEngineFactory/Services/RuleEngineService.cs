using BusinessRuleEngine.RuleEngineFactory.Interfaces;

namespace BusinessRuleEngine.RuleEngineFactory.Services
{
    /// <summary>
    /// This is service which is used to call the specific Rule type based on object creation.
    /// </summary>
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