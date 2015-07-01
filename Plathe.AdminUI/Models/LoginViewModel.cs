using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plathe.AdminUI.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Vul een geldige waarde in.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vul een geldige waarde in.")]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }

        [HiddenInput]
        public string ReturnUrl { get; set; }

    }
}