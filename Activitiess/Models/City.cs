using System;
using System.Collections.Generic;

namespace Activities.Models
{
    public partial class City
    {
        public City()
        {
            Activitiys = new HashSet<Activitiy>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; } = null!;

        public virtual ICollection<Activitiy> Activitiys { get; set; }
    }
}
