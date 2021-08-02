using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlan.Data
{
    public class RentACar
    {
        [Key]
        public int RentACarId { get; set; }
        [Required]
        public Guid UserID { get; set; }

        [Required]
        public string CarName { get; set; }

        [Required]
        public int Year { get; set; }

        [ForeignKey(nameof(Trip))]
        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
