using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KursTRPO.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("UserDB") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}