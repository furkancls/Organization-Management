using System;
using System.Collections.Generic;

namespace Activities.Models
{
    public partial class Company
    {
        public Company()
        {
            Activitiys = new HashSet<Activitiy>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? WebSite { get; set; }
        public string? CompanyEmail { get; set; }
        public string Password { get; set; } = null!;

        public virtual ICollection<Activitiy> Activitiys { get; set; }
    }
}
