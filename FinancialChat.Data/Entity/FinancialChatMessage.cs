using System;

namespace FinancialChat.Data.Entity
{
    /// <summary>
    /// Used to store all messages sent in the financial chat.
    /// </summary>
    public class FinancialChatMessage
    {
        //Primary Key
        public int FinancialChatMessageIDNumber { get; set; }

        //Message sent by sender
        public string Message { get; set; }

        //User name of Sender (who sends the message)
        public string SenderUserName { get; set; }

        //Date and time when message was sent by the sender
        public DateTime MessageSentUtc { get; set; }
    }
}