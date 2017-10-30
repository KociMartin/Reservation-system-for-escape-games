using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ASP_DU_2.Model
{
    /// <summary>
    /// Model rezervaci a validace
    /// </summary>
    public class Reservation
    {
        public virtual Room CurrentRoom { get; set; }
        public virtual Customer CurrentCustomer { get; set; }

        public int Id{ get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Date cannot be empty")]
        [DataType(DataType.Date,ErrorMessage ="Date must be type of DateTime")]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [StringLength(maximumLength: 500, ErrorMessage = "Description must contain maximum of 500 characters")]
        [Display(Name = "Note")]
        public string Description { get; set; }

        public int ReservationHour { get; set; }

    }
}
