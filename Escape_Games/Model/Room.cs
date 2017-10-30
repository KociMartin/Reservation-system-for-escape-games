using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ASP_DU_2.Model
{
    public class Room
    {
        /// <summary>
        /// Model mistnosti a validace
        /// </summary>
        public Room()
        {
            this.Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name cannot be empty")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Name must contain 1-50 characters")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Description cannot be empty")]
        [StringLength(maximumLength: 500, MinimumLength = 50, ErrorMessage = "Description must contain 50-500 characters")]
        [Display(Name = "Room Description: ")]
        public string Description { get; set; }

        [Display(Name = "Hour: ")]
        public string OpeningHours { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        /// <summary>
        /// Metoda, ktera ze stringu Oteviracich hodin udela List cisel pro lepsi praci ve view
        /// </summary>
        /// <param name="OpeningHours"></param>
        /// <returns></returns>
        public List<int> OpeningHoursNumbers()
        {
            return OpeningHours.Split(',').Select(x => int.Parse(x)).ToList();
        }

        /// <summary>
        /// Vraci Reservace vytvoreny na dane datum u API
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        public List<int> OccupiedOpeningHours(DateTime DateArg)
        {
            return (from res in Reservations
                    where res.Date.Date == DateArg.Date
                    select res.ReservationHour).ToList();
        }

    }
}
