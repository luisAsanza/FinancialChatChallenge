using FinancialChat.Data.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialChat.Data.Map
{
    /// <summary>
    /// Used to configure how the FinancialChatMessage entity will be mapped to the database.
    /// </summary>
    public class FinancialChatMessageMap
    {
        public FinancialChatMessageMap(EntityTypeBuilder<FinancialChatMessage> builder)
        {
            builder.HasKey(t => t.FinancialChatMessageIDNumber);
            builder.Property(t => t.SenderUserName).IsRequired().HasMaxLength(256);
            builder.Property(t => t.Message).IsRequired();
            builder.Property(t => t.MessageSentUtc).IsRequired();
        }
    }
}
