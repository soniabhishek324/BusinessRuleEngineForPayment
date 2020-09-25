using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessRuleEngine.Controllers;
using BusinessRuleEngine.Models;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using BusinessRuleEngine.RuleEngineFactory.Constants;

namespace BusinessRuleEngine.Tests.Controllers
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public sealed class HomeControllerTest
    {
        [TestMethod]
        [TestCategory("unit")]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [TestCategory("unit")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Payment_Check_NullArguments()
        {
            // Arrange
            HomeController controller = new HomeController();

            var engineModel = new EngineModel();
            // Act
            ViewResult result = controller.Payment(engineModel) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [TestCategory("unit")]
        // If the Payment is for Physical Product , Generate a packing slip for shipping.
        // If the Payment is for physical product or book, generate a commission payment to agent.
        public void Payment_For_PhysicalProduct()
        {
            // Arrange
            HomeController controller = new HomeController();

            var engineModel = new EngineModel();
            engineModel.RuleType = (int)RuleTypeEnum.PhysicalProduct;
            // Act
            var result = controller.Payment(engineModel) as ViewResult;
            Assert.IsNotNull(result);

            var actualResult = result.ViewBag.Message;

            StringBuilder expectedResult = new StringBuilder();
            expectedResult.Append(RuleEngineMessages.GeneratePackingSlip);
            expectedResult.Append(RuleEngineMessages.AND);
            expectedResult.Append(RuleEngineMessages.GenerateCommisionToAgent);

            Assert.AreNotEqual(expectedResult.ToString(), actualResult);
        }

        [TestMethod]
        [TestCategory("unit")]
        // If the Payment is for Book, Create a duplicate packing slip for royalty department.
        // If the Payment is for physical product or book, generate a commission payment to agent.
        public void Payment_For_Book()
        {
            // Arrange
            HomeController controller = new HomeController();

            var engineModel = new EngineModel();
            engineModel.RuleType = (int)RuleTypeEnum.Book;
            // Act
            ViewResult result = controller.Payment(engineModel) as ViewResult;
            Assert.IsNotNull(result);

            var actualResult = result.ViewBag.Message;

            StringBuilder expectedResult = new StringBuilder();
            expectedResult.Append(RuleEngineMessages.DuplicatePackingSlip);
            expectedResult.Append(RuleEngineMessages.AND);
            expectedResult.Append(RuleEngineMessages.GenerateCommisionToAgent);

            Assert.AreEqual(expectedResult.ToString(), actualResult);
        }

        [TestMethod]
        [TestCategory("unit")]
        // If the Payment is for Membership, Activate that membership.
        // If the payment is for Membership or upgrade membership, email the owner and inform them of the activation/upgrade.
        public void Payment_For_MemberShip()
        {
            // Arrange
            HomeController controller = new HomeController();

            var engineModel = new EngineModel();
            engineModel.RuleType = (int)RuleTypeEnum.Membership;
            // Act
            ViewResult result = controller.Payment(engineModel) as ViewResult;
            Assert.IsNotNull(result);

            var actualResult = result.ViewBag.Message;

            StringBuilder expectedResult = new StringBuilder();
            expectedResult.Append(RuleEngineMessages.ActivateMemberShip);
            expectedResult.Append(RuleEngineMessages.AND);
            expectedResult.Append(RuleEngineMessages.SendEmailToOwner);

            Assert.AreEqual(expectedResult.ToString(), actualResult);
        }

        [TestMethod]
        [TestCategory("unit")]
        // If the Payment is an upgrade Membership, Apply upgrade.
        // If the payment is for Membership or upgrade membership, email the owner and inform them of the activation/upgrade.
        public void Payment_For_UpgradeMemberShip()
        {
            // Arrange
            HomeController controller = new HomeController();

            var engineModel = new EngineModel();
            engineModel.RuleType = (int)RuleTypeEnum.MembershipUpgrade;
            // Act
            ViewResult result = controller.Payment(engineModel) as ViewResult;
            Assert.IsNotNull(result);

            var actualResult = result.ViewBag.Message;

            StringBuilder expectedResult = new StringBuilder();
            expectedResult.Append(RuleEngineMessages.UpgradeMemberShip);
            expectedResult.Append(RuleEngineMessages.AND);
            expectedResult.Append(RuleEngineMessages.SendEmailToOwner);

            Assert.AreEqual(expectedResult.ToString(), actualResult);
        }

        [TestMethod]
        [TestCategory("unit")]
        // If the Payment is for Video named as "Learning to Ski", add a free "First Aid" video to the packing slip and for rest 
        // viedos show the General Packing slip message.
        public void Payment_For_Video_With_ViedoName()
        {
            var controller = new HomeController();
            var engineModel = new EngineModel();
            engineModel.RuleType = (int)RuleTypeEnum.Video;
            engineModel.VideoName = "Learning to Ski";

            var result = controller.Payment(engineModel) as ViewResult;
            Assert.IsNotNull(result);

            var actualResult = result.ViewBag.Message;

            StringBuilder expectedResult = new StringBuilder();
            expectedResult.Append(RuleEngineMessages.GeneratePackingSlip);
            expectedResult.Append(RuleEngineMessages.AND);
            expectedResult.Append(RuleEngineMessages.GenerateCommisionToAgent);
            expectedResult.Append(RuleEngineMessages.AND);
            expectedResult.Append(RuleEngineMessages.VideoAddingFreeAid);
            Assert.AreEqual(expectedResult.ToString(), actualResult);
        }

        [TestMethod]
        [TestCategory("unit")]
        // If the Payment is for Video named as "Learning to Ski", add a free "First Aid" video to the packing slip and for rest 
        // viedos show the General Packing slip message.
        public void Payment_For_Video_WithOut_ViedoName()
        {
            var controller = new HomeController();
            var engineModel = new EngineModel();
            engineModel.RuleType = (int)RuleTypeEnum.Video;

            var result = controller.Payment(engineModel) as ViewResult;
            Assert.IsNotNull(result);

            var actualResult = result.ViewBag.Message;

            StringBuilder expectedResult = new StringBuilder();
            expectedResult.Append(RuleEngineMessages.GeneratePackingSlip);
            expectedResult.Append(RuleEngineMessages.AND);
            expectedResult.Append(RuleEngineMessages.GenerateCommisionToAgent);
            Assert.AreEqual(expectedResult.ToString(), actualResult);
        }
    }
}
