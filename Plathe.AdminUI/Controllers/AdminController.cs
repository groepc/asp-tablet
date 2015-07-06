using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Plathe.AdminUI.Models;
using Plathe.AdminUI.Infrastructure;

namespace Plathe.AdminUI.Controllers {

    [Authorize(Roles = "Administratie")]
    public class AdminController : Controller {

        public ActionResult Index() {
            return View(UserManager.Users);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateModel model) {
            if (ModelState.IsValid) {
                AppUser user = new AppUser { UserName = model.Name, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName};
                IdentityResult result = await UserManager.CreateAsync(user,
                    model.Password);
                if (result.Succeeded) {
                    return RedirectToAction("Index");
                } else {
                    AddErrorsFromResult(result);
                }
            }
            else
            {
                if (model.FirstName == null)
                {
                    ModelState.AddModelError("", "Voornaam is een verplicht veld");
                }
                if (model.LastName == null)
                {
                    ModelState.AddModelError("", "Achternaam is een verplicht veld");
                }
                if (model.Name == null)
                {
                    ModelState.AddModelError("", "Gebruikersnaam is een verplicht veld");
                }
                if (model.Email == null)
                {
                    ModelState.AddModelError("", "E-mailadres is een verplicht veld");
                }
                if (model.Password == null)
                {
                    ModelState.AddModelError("", "Wachtwoord is een verplicht veld");
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id) {
            AppUser user = await UserManager.FindByIdAsync(id);
            if (user != null) {
                IdentityResult result = await UserManager.DeleteAsync(user);
                if (result.Succeeded) {
                    return RedirectToAction("Index");
                } else {
                    return View("Error", result.Errors);
                }
            } else {
                return View("Error", new string[] { "Gebruiker niet gevonden" });
            }
        }

        public async Task<ActionResult> Edit(string id) {
            AppUser user = await UserManager.FindByIdAsync(id);
            if (user != null) {
                return View(user);
            } else {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(string id, string email, string password, string firstname, string lastname) {
            AppUser user = await UserManager.FindByIdAsync(id);
            if (user != null) {
                user.Email = email;
                user.LastName = lastname;
                user.FirstName = firstname;
                IdentityResult validEmail = await UserManager.UserValidator.ValidateAsync(user);
                if (!validEmail.Succeeded) {
                    AddErrorsFromResult(validEmail);
                }
                IdentityResult validPass = null;
                if (password != string.Empty) {
                    validPass = await UserManager.PasswordValidator.ValidateAsync(password);
                    if (validPass.Succeeded) {
                        user.PasswordHash = UserManager.PasswordHasher.HashPassword(password);
                    } else {
                        AddErrorsFromResult(validPass);
                    }
                }
                if (firstname == null)
                {
                    ModelState.AddModelError("", "Voornaam is een verplicht veld");
                }
                if (lastname == null)
                {
                    ModelState.AddModelError("", "Achternaam is een verplicht veld");
                }
                if ((validEmail.Succeeded && validPass == null && firstname != null && lastname != null) || (validEmail.Succeeded && password != string.Empty && validPass.Succeeded && firstname != null && lastname != null))
                {
                    IdentityResult result = await UserManager.UpdateAsync(user);
                    if (result.Succeeded) {
                        return RedirectToAction("Index");
                    } else {
                        AddErrorsFromResult(result);
                    }
                }
            } else {
                ModelState.AddModelError("", "Gebruiker niet gevonden");
            }
            return View(user);
        }

        private void AddErrorsFromResult(IdentityResult result) {
            foreach (string error in result.Errors) {
                ModelState.AddModelError("", error);
            }
        }

        private AppUserManager UserManager {
            get {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }

    }
}
