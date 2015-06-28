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

        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Display(Name = "Locatie")]
        public string Location { get; set; }

        [Display(Name = "Omschrijving")]
        public string Description { get; set; }

        [Display(Name = "Datum/tijd")]
        public DateTime TimeFound { get; set; }

        [Display(Name = "Opgehaald")]
        public bool Collected { get; set; }
    }
}
