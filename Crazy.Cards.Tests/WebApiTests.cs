using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Crazy.Cards.Web.Controllers;
using Crazy.Cards.Web.Models;
using System.Collections.Generic;
using System.Linq;
using Crazy.Cards.Core;
using Moq;
using Crazy.Cards.Core.DomainModels;

namespace Crazy.Cards.Tests
{
    [TestClass]
    public class WebApiTests
    {
        CardOffersController controller;
        [TestInitialize]
        public void Init()
        {
            //Arrange
            CustomerViewModel vm = Mock.Of<CustomerViewModel>(c => c.EmploymentStatus == Core.Enumerations.EmploymentStatus.Unemployed);

            List<CreditCard> unemployeedCards = new List<CreditCard>() {
                                new CreditCard() {
                                    CardName = "TestCard",
                                    CardDescription = "Test Card Description"
                                        }
                                };
            var mock = new Mock<ICardsRepository>();
            mock.Setup(
                        l => l.GetCards(
                                Core.Enumerations.EmploymentStatus.Unemployed, 
                                It.IsAny<decimal>()
                                       )

                        ).Returns(unemployeedCards);

           
            controller = new CardOffersController(mock.Object);

        }
        [TestMethod]
        public void Get_TestCard_For_Unemployeed()
        {

            //Act
            List<OfferViewModel> result = controller.GetOffers(new Web.Models.CustomerViewModel() { EmploymentStatus = Core.Enumerations.EmploymentStatus.Unemployed }) as List<OfferViewModel>;


            //Assert
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result.First().CardName, "TestCard");

        }
    }
}
