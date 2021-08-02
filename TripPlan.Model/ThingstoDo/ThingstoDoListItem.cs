using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlan.Model.ThingstoDo
{
    public class ThingstoDoListItem
    {
        [Display(Name = "Things To Do Id")]

        public int ThingsToDoId { get; set; }
        public string Activity { get; set; }
        public string Description { get; set; }
        [Display(Name = "Trip Name")]
        public string TripName { get; set; }
    }
}
