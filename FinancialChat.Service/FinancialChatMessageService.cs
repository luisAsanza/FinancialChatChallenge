using System;
using System.Collections.Generic;
using System.Linq;
using FinancialChat.Data.Entity;
using FinancialChat.Repository;

namespace FinancialChat.Service
{
    /// <summary>
    /// Implementation of business logic methods for entity FinancialChatMessage
    /// </summary>
    public class FinancialChatMessageService : IFinancialChatMessageService
    {
        #region Private methods and Constructor

        private IFinancialChatMessageRepository _financialChatMessageRepository;

        public FinancialChatMessageService(IFinancialChatMessageRepository financialChatMessageRepository)
        {
            _financialChatMessageRepository = financialChatMessageRepository;
        }

        #endregion

        /// <summary>
        /// Get only 50 most recent messages from the chat
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FinancialChatMessage> GetLastFiftyFinancialChatMessages()
        {
            return _financialChatMessageRepository.GetAll().OrderBy(m => m.MessageSentUtc).TakeLast(50);
        }

        /// <summary>
        /// Store a message to the database
        /// </summary>
        /// <param name="financialChatMessage"></param>
        public void PostFinancialChatMessage(FinancialChatMessage financialChatMessage)
        {
            //Always override "Message Sent date" to current Utc date and time. Utc allows to support TZ.
            financialChatMessage.MessageSentUtc = DateTime.UtcNow;

            _financialChatMessageRepository.Insert(financialChatMessage);
        }
    }
}
