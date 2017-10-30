using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_DU_2.Model
{
    /// <summary>
    /// Pomocna trida pro praci s modely ve Views
    /// </summary>
    public class ModelKeeper
    {
        public Customer customer { get; set; }
        public Reservation reservation { get; set; }
        public Room room { get; set; }

    }
}
