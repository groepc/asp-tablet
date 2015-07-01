using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Plathe.Domain.AbstractServices;
using Plathe.Domain.Entities;
using Plathe.Domain.Services;

namespace Plathe.WebUI.Models
{
    public class ReviewViewModel
    {
        
        [Required(ErrorMessage = "Vul een unieke code in.")]
        [Display(Name = "Ticket code")]
        public string TicketID { get; set; }

        [Required]
        public int MovieID { get; set; }

        [Required(ErrorMessage = "Vul een review in.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Vul jouw review in")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Geef deze film een rating.")]
        [Range(1, 5, ErrorMessage = "Vul een waarde in tussen de 1 en de 5.")]
        [Display(Name = "Geef een rating (1 t/m 5)")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Vul je e-mailadres in.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Vul een geldig e-mailadres in.")]
        [Display(Name = "Vul je e-mailadres in")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Vul je naam in.")]
        [Display(Name = "Vul je naam in")]
        public string UserName { get; set; }

        public Movie Movie { get; set; }
    }
}