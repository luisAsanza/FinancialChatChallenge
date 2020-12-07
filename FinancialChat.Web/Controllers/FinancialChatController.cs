using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FinancialChat.Web.Controllers
{
    //[Authorize]
    public class FinancialChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
