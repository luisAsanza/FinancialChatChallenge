using System;
using System.Collections.Generic;
using System.Linq;
using FinancialChat.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace FinancialChat.Repository
{
    /// <summary>
    /// Implementation of repository for FinancialChatMessage.
    /// Since this is a demo purpose, a base repository was not implemented.
    /// </summary>
    public class FinancialChatMessageRepository : IFinancialChatMessageRepository
    {
        #region Private members and Constructor

        private readonly FinancialChatContext _context;
        private DbSet<FinancialChatMessage> _entities;

        public FinancialChatMessageRepository(FinancialChatContext context)
        {
            _context = context;
            _entities = _context.Set<FinancialChatMessage>();
        }

        #endregion
        
        public IEnumerable<FinancialChatMessage> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public void Insert(FinancialChatMessage financialChatMessage)
        {
            if (financialChatMessage == null)
            {
                throw new ArgumentNullException(nameof(financialChatMessage));
            }

            _entities.Add(financialChatMessage);
            _context.SaveChanges();
        }

        //Save changes that are in memory, to the database
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
