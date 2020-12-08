using FinancialChat.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FinancialChat.Web.Controllers
{
    /// <summary>
    /// Controller to handle financial chat
    /// </summary>
    [Authorize]
    public class FinancialChatController : Controller
    {
        #region Private members and Constructor

        private IFinancialChatMessageService _financialChatMessageService;

        public FinancialChatController(IFinancialChatMessageService financialChatMessageService)
        {
            _financialChatMessageService = financialChatMessageService;
        }

        #endregion

        [ResponseCache(NoStore = true, Duration = 0)]
        public IActionResult Index()
        {
            var model = _financialChatMessageService.GetLastFiftyFinancialChatMessages();

            return View(model);
        }
    }
}