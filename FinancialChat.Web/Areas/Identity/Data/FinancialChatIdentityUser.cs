using Microsoft.AspNetCore.Identity;

namespace FinancialChat.Web.Areas.Identity.Data
{
    /// <summary>
    /// Derived class FinancialChatIdentityUser is used to define customized properties
    /// </summary>
    public class FinancialChatIdentityUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}