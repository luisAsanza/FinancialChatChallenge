using System.Collections.Generic;
using FinancialChat.Data.Entity;

namespace FinancialChat.Service
{
    /// <summary>
    /// Used to declare business logic method contracts for entity FinancialChatMessage
    /// </summary>
    public interface IFinancialChatMessageService
    {
        IEnumerable<FinancialChatMessage> GetLastFiftyFinancialChatMessages();
        void PostFinancialChatMessage(FinancialChatMessage financialChatMessage);
    }
}
