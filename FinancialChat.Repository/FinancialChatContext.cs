using FinancialChat.Data.Entity;
using FinancialChat.Data.Map;
using Microsoft.EntityFrameworkCore;

namespace FinancialChat.Repository
{
    /// <summary>
    /// Db Context created only for 
    /// </summary>
    public class FinancialChatContext : DbContext
    {
        #region Constructor

        public FinancialChatContext(DbContextOptions<FinancialChatContext> options) : base(options)
        {
        }

        #endregion

        //Need to override OnModelCreating to further configuration of FinancialChatMessage entity
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Discards to reduce memory allocation (C# 7)
            _ = new FinancialChatMessageMap(modelBuilder.Entity<FinancialChatMessage>());
        }
    }
}
