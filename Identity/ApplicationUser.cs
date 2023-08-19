using Microsoft.AspNet.Identity.EntityFramework;

namespace EticaretWeb.Identity;

public class ApplicationUser: IdentityUser
{
    public string Name { get; set; }

    public string Surname { get; set; }
}