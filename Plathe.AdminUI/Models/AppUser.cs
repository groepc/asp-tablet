using Microsoft.AspNet.Identity.EntityFramework;

namespace Plathe.AdminUI.Models {
    public class AppUser : IdentityUser {
        // additional properties will go here
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
