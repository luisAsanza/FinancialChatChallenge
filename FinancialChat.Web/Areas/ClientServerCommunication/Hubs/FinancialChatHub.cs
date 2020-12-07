using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace FinancialChat.Web.Areas.ClientServerCommunication.Hubs
{
    /// <summary>
    /// SignalR Hub class used to handle Financial Chat client-server communication.
    /// </summary>
    public class FinancialChatHub : Hub
    {
        /// <summary>
        /// Used by a connected client to send a message to all clients.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(string user, string message)
        {
            //TODO: Store message to DB

            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}