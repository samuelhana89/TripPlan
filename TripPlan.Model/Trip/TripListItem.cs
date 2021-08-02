using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlan.Model.Trip
{
    public class TripListItem
    {
        public int TripId { get; set; }

        [Display(Name = "Trip Name")]
        public string TripName { get; set; }

        [Display(Name = "Destination City")]
        public string DestinationCity { get; set; }

        public string Description { get; set; }

        [Display(Name = "Start Date")]
        public DateTimeOffset StartDate { get; set; }
    }
}
