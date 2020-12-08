using System;
using System.Collections.Generic;
using System.Linq;
using FinancialChat.Data.Entity;
using FinancialChat.Repository;
using FinancialChat.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace FinancialChat.Test.Service
{
    [TestClass]
    public class FinancialChatMessageServiceTest
    {
        [TestMethod, Description("Unit test for GetLastFiftyFinancialChatMessages service method. Only up to 50 records must be returned.")]
        public void GetLastFiftyFinancialChatMessages_Exist60Records_Only50Returned()
        {
            //Arrange
            var financialChatRepository = Substitute.For<IFinancialChatMessageRepository>();
            financialChatRepository.GetAll().Returns(GetFakeFinancialChatMessageList(70));
            var expected = 50;
            var target = new FinancialChatMessageService(financialChatRepository);

            //Act
            var current = target.GetLastFiftyFinancialChatMessages().ToList().Count;

            //Assert
            Assert.AreEqual(expected, current);
        }

        [TestMethod, Description("Unit test for GetLastFiftyFinancialChatMessages service method. Less than 50 records will be returned all.")]
        public void GetLastFiftyFinancialChatMessages_ExistLessThan50Records_LessThan50Returned()
        {
            //Arrange
            var financialChatRepository = Substitute.For<IFinancialChatMessageRepository>();
            financialChatRepository.GetAll().Returns(GetFakeFinancialChatMessageList(30));
            var expected = 30;
            var target = new FinancialChatMessageService(financialChatRepository);

            //Act
            var current = target.GetLastFiftyFinancialChatMessages().ToList().Count;

            //Assert
            Assert.AreEqual(expected, current);
        }

        /// <summary>
        /// Generate fake data for Chat Message table
        /// </summary>
        /// <param name="numberOfRecords"></param>
        /// <returns></returns>
        private IEnumerable<FinancialChatMessage> GetFakeFinancialChatMessageList(int numberOfRecords)
        {
            var data = new List<FinancialChatMessage>();
            var random = new Random();

            for (int i = 1; i <= numberOfRecords; i++)
            {
                data.Add(new FinancialChatMessage()
                {
                    FinancialChatMessageIDNumber = i,
                    Message = "message " + i,
                    SenderUserName = "user" + i,
                    MessageSentUtc = DateTime.UtcNow.AddSeconds(5*i)
                });
            }

            return data;
        }
    }
}
