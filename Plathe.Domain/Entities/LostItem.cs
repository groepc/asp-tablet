using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.Entities
{
    public class LostItem
    {
        [Display(Name = "Nummer")]
        public int LostItemId { get; set; }

        [Required(ErrorMessage = "Vul een naam in.")]
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vul een locatie in.")]
        [Display(Name = "Locatie")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Vul een omschrijving in.")]
        [Display(Name = "Omschrijving")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Vul een datum en tijd in.")]
        [Display(Name = "Datum/tijd")]
        [DataType(DataType.DateTime)] 
        public DateTime TimeFound { get; set; }

        [Display(Name = "Opgehaald")]
        public bool Collected { get; set; }
    }
}
