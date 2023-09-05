using Microsoft.AspNetCore.Identity;

namespace HotPizzaShop.Services.Identity.MainModule
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
