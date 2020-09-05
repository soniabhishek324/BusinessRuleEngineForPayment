using BusinessRuleEngine.Models;
using BusinessRuleEngine.RuleEngineFactory.Interfaces;

namespace BusinessRuleEngine.RuleEngineFactory
{
    public static class RuleEngineBuilder
    {
        public static IRuleEngine GetRuleEngineFromType(int paymentType, string videoName)
        {
            switch ((RuleTypeEnum)paymentType)
            {
                case RuleTypeEnum.PhysicalProduct:
                    return new PhysicalProduct();
                case RuleTypeEnum.Book:
                    return new Book();
                case RuleTypeEnum.Membership:
                    return new Membership();
                case RuleTypeEnum.MembershipUpgrade:
                    return new MembershipUpgrade();
                case RuleTypeEnum.Video:
                    return new Video(videoName);
                default:
                    return null;
            }
        }
    }
}