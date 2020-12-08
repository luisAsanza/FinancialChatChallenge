using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinancialChat.Web.Areas.Identity.Data
{
    public class IdentityContext : IdentityDbContext<FinancialChatIdentityUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //New properties max length must be set, otherwise they are created with varchar(max) type
            builder.Entity<FinancialChatIdentityUser>().Property(u => u.FirstName).HasMaxLength(50);
            builder.Entity<FinancialChatIdentityUser>().Property(u => u.LastName).HasMaxLength(50);
        }
    }
}
