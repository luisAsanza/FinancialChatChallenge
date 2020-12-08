using System;
using System.Linq;
using System.Threading.Tasks;
using FinancialChat.Data.Entity;
using FinancialChat.Service;
using FinancialChat.StockBot;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FinancialChat.Web.Areas.ClientServerCommunication.Hubs
{
    /// <summary>
    /// SignalR Hub class used to handle Financial Chat client-server communication.
    /// </summary>
    [Authorize]
    public class FinancialChatHub : Hub
    {
        #region Private members and Constructor

        private readonly IFinancialChatMessageService _financialChatMessageService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<FinancialChatHub> _logger;
        private readonly IStockBot _stockBot;

        public FinancialChatHub(IFinancialChatMessageService financialChatMessageService, IStockBot stockBot, 
            IConfiguration configuration, ILogger<FinancialChatHub> logger)
        {
            _financialChatMessageService = financialChatMessageService;
            _stockBot = stockBot;
            _configuration = configuration;
            _logger = logger;
        }

        #endregion
        
        /// <summary>
        /// Used by a connected client to send a message to all clients.
        /// </summary>
        /// <param name="message">Message sent by sender</param>
        /// <returns></returns>
        public async Task SendMessage(string message)
        {
            var firstWordOfMessage = message.Trim().Split(" ").FirstOrDefault() ?? "";
            bool isStockCommand = firstWordOfMessage.StartsWith("/stock=");

            if (isStockCommand)
            {
                await HandleStockRequest(firstWordOfMessage);
            }
            else
            {
                //Prior pushing message to all clients, store it in database
                _financialChatMessageService.PostFinancialChatMessage(new FinancialChatMessage()
                {
                    Message = message,
                    SenderUserName = Context.User.Identity.Name
                });

                //Push message to all clients
                await Clients.All.SendAsync("ReceiveMessage", Context.User.Identity.Name, message);
            }
        }

        /// <summary>
        /// Attempt to get stock report based on stock code. Also logs any error that comes from the bot.
        /// A user friendly error is thrown to the client to display in the chat is case an error occurs.
        /// </summary>
        /// <param name="firstWordOfMessage"></param>
        /// <returns></returns>
        private async Task HandleStockRequest(string firstWordOfMessage)
        {
            try
            {
                var stockCode = firstWordOfMessage.Replace("/stock=", "");
                var stockQuote = _stockBot.GetStockQuote(stockCode);
                await Clients.Caller.SendAsync("ReceiveMessage", "Stock Bot", stockQuote);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error while getting Stock report from Stooq provider.", null);
                throw new Exception("Message couldn't be delivered. Please retry.");
            }
        }
    }
}