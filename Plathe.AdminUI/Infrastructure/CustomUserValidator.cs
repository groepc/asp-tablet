using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Plathe.AdminUI.Models;

namespace Plathe.AdminUI.Infrastructure {

    public class CustomUserValidator : UserValidator<AppUser> {

        public CustomUserValidator(AppUserManager mgr)
            : base(mgr) {
        }

        public override async Task<IdentityResult> ValidateAsync(AppUser user) {
            IdentityResult result = await base.ValidateAsync(user);

            if (!user.Email.ToLower().EndsWith("@plathe.nl")) {
                var errors = result.Errors.ToList();
                errors.Add("Alleen plathe.nl e-mailadressen zijn toegestaan");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}
