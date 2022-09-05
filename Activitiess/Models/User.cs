using System;
using System.Collections.Generic;

namespace Activities.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserSurname { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string UserPasswordAgain { get; set; } = null!;
        public int RoleId { get; set; }

        public virtual UserRole Role { get; set; } = null!;
    }
}
