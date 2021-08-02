using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlan.Data
{
    public class Trip
    {

        [Key]
        public int TripId { get; set; }
        [Required]
        public Guid UserID { get; set; }

        [Required]
        public string TripName { get; set; }

        [Required]
        public string DestinationCity { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
    }
}
