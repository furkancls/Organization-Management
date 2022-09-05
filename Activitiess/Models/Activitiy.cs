using System;
using System.Collections.Generic;

namespace Activities.Models
{
    public partial class Activitiy
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; } = null!;
        public DateTime? ActivityDate { get; set; }
        public DateTime? ApplicationDeadline { get; set; }
        public string? Description { get; set; }
        public int? Quota { get; set; }
        public string? Address { get; set; }
        public int CityId { get; set; }
        public string? Isticked { get; set; }
        public decimal? Price { get; set; }
        public int CompanyId { get; set; }
        public byte CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual City City { get; set; } = null!;
        public virtual Company Company { get; set; } = null!;
    }
}
