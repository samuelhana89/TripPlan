using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlan.Data
{
    public class ThingsToDo
    {
        [Key]
        public int ThingsToDoId { get; set; }
        [Required]
        public Guid UserID { get; set; }

        [Required]
        public string Activity { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey(nameof(Trip))]
        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
