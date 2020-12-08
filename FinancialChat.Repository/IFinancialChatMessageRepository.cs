using System.Collections.Generic;
using FinancialChat.Data.Entity;

namespace FinancialChat.Repository
{
    /// <summary>
    /// FinancialChatMessage Repository contract
    /// </summary>
    public interface IFinancialChatMessageRepository
    {
        IEnumerable<FinancialChatMessage> GetAll();
        void Insert(FinancialChatMessage financialChatMessage);
        void SaveChanges();
    }
}