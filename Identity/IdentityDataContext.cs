using Microsoft.AspNet.Identity.EntityFramework;

namespace EticaretWeb.Identity;

public class IdentityDataContext:IdentityDbContext<ApplicationUser>
{
    public IdentityDataContext(): base("connectionString")
    {
         
    }
}