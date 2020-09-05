using BusinessRuleEngine.RuleEngineFactory.Constants;
using BusinessRuleEngine.RuleEngineFactory.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.RuleEngineFactory
{
    public class Video : PhysicalProduct, IRuleEngine
    {
        public string VideoName { get; set; }

        public Video(string videoName)
        {
            this.VideoName = videoName;
        }
        public new string ProcessRule()
        {
            StringBuilder str = new StringBuilder();

            str.Append(base.ProcessRule());

            if (IsAdditionalVideoNeeded())
            {
                str.Append(RuleEngineMessages.AND);
                str.Append(RuleEngineMessages.VideoAddingFreeAid);
            }
            return str.ToString();
        }

        private bool IsAdditionalVideoNeeded()
        {
            List<string> VideoNameConditions = new List<string>() { RuleEngineMessages.VideoNameLearningToSki };

            return VideoNameConditions.Contains(VideoName);
        }
    }
}