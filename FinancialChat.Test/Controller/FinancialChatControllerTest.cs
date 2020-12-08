using System;
using System.Collections.Generic;
using System.Linq;
using FinancialChat.Data.Entity;
using FinancialChat.Service;
using FinancialChat.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace FinancialChat.Test.Controller
{
    [TestClass]
    public class FinancialChatControllerTest
    {
        [TestMethod, Description("Method for Index method. Verify it returns ViewResult with a list of IEnumerable<FinancialChatMessage>")]
        public void Index_ReturnsAViewResult_WithAListOfFinancialChatMessages()
        {
            // Arrange
            var repository = Substitute.For<IFinancialChatMessageService>();
            repository.GetLastFiftyFinancialChatMessages().Returns(GetFakeFinancialChatMessageList());
            var target = new FinancialChatController(repository);
            const int expected = 50;

            // Act
            var result = target.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var resultViewResult = (ViewResult) result;
            Assert.IsInstanceOfType(resultViewResult.ViewData.Model, typeof(IEnumerable<FinancialChatMessage>));
            Assert.AreEqual(expected, ((IEnumerable<FinancialChatMessage>)resultViewResult.ViewData.Model).Count());
        }

        private IEnumerable<FinancialChatMessage> GetFakeFinancialChatMessageList()
        {
            var data = new List<FinancialChatMessage>();
            var random = new Random();

            for (int i = 1; i <= 50; i++)
            {
                data.Add(new FinancialChatMessage()
                {
                    FinancialChatMessageIDNumber = i,
                    Message = "message " + i,
                    SenderUserName = "user" + i,
                    MessageSentUtc = DateTime.UtcNow.AddSeconds(5 * i)
                });
            }

            return data;
        }
    }
}
