using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlan.Model.RentACar
{
    public class RentACarCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Car Name")]
        public string CarName { get; set; }

        [Required]
        
        public int Year { get; set; }


        public int TripId { get; set; }
    }
}

