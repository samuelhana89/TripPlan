using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlan.Model.Trip
{
    public class TripCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please, Enter at least 2 chatracters")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field")]
        [Display(Name = "Trip Name")]
        public string TripName { get; set; }

        [MinLength(2, ErrorMessage = "Please, Enter at least 2 chatracters")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field")]
        [Required]
        [Display(Name = "Destination City ")]
        public string DestinationCity { get; set; }

        [MinLength(2, ErrorMessage = "Please, Enter at least 2 chatracters")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "start date")]
        public DateTimeOffset StartDate { get; set; }
    }
}
