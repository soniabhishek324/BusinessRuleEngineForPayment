using BusinessRuleEngine.Models;
using BusinessRuleEngine.RuleEngineFactory;
using BusinessRuleEngine.RuleEngineFactory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessRuleEngine.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var engineModel = new EngineModel();
            ConfigureViewModel(engineModel);
            return View(engineModel);
        }

        public ActionResult Payment(EngineModel engineModel)
        {
            if (engineModel.RuleType is 0)
            {
                throw new ArgumentNullException();
            }

            var ruleEngine = RuleEngineBuilder.GetRuleEngineFromType(engineModel.RuleType, engineModel.VideoName);
            var service = new RuleEngineService(ruleEngine);
            ViewBag.Message = service.StartProcess();

            return View();
        }

        private void ConfigureViewModel(EngineModel engineModel)
        {
            var products = RuleTypeLoopUp.FetchRuleTypeLoopUp();
            engineModel.RuleTypeLoopUpList = new SelectList(products, "ID", "Name");
        }
    }
}