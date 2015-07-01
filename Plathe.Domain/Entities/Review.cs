using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plathe.Domain.Entities
{
    public class Review
    {
        public int ReviewID { get; set; }

        public string TicketID { get; set; }

        public int MovieID { get; set; }

        public int ReviewStatus { get; set; }
        
        public string Content { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Movie Movie { get; set; }

    }
}