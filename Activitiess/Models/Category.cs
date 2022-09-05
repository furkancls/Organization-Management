using System;
using System.Collections.Generic;

namespace Activities.Models
{
    public partial class Category
    {
        public Category()
        {
            Activitiys = new HashSet<Activitiy>();
        }

        public byte CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Activitiy> Activitiys { get; set; }
    }
}
