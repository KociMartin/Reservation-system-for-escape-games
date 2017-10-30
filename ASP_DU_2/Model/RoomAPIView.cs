using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_DU_2.Model
{
    /// <summary>
    /// Trida pro zobrazeni mistnosti a jejich volnych oteviracich hodin
    /// </summary>
    public class RoomAPIView
    {
        public Room Room { get; set; }
        public List<int> FreeHours { get; set; }
        
    }
}
