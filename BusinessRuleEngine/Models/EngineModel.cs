using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessRuleEngine.Models
{
    public class EngineModel
    {
        [Required(ErrorMessage = "Please select Rule to process")]
        public int RuleType { get; set; }
        public SelectList RuleTypeLoopUpList { get; set; }

        public string VideoName { get; set; }
    }

    public class RuleTypeLoopUp
    {
        public int ID { set; get; }
        public string Name { set; get; }

        public static IEnumerable<RuleTypeLoopUp> FetchRuleTypeLoopUp()
        {
            return new List<RuleTypeLoopUp>()
            {
                new RuleTypeLoopUp(){ ID = 1, Name = "Physical Product" },
                new RuleTypeLoopUp(){ ID = 2, Name = "Book" },
                new RuleTypeLoopUp(){ ID = 3, Name = "Membership" },
                new RuleTypeLoopUp(){ ID = 4, Name = "Membership Upgrade" },
                new RuleTypeLoopUp(){ ID = 5, Name = "Video" }
            };
        }
    }
}