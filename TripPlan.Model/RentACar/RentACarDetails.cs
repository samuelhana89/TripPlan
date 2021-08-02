using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlan.Model.RentACar
{
    public class RentACarDetails
    {
        [Display(Name = "Rent a Car Id")]
        public int RentACarId { get; set; }

        public string CarName { get; set; }

        public int Year { get; set; }

        [Display(Name = "Trip Name")]
        public string TripName { get; set; }
    }
}
