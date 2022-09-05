using Activities.Models;

namespace Acitivity.ViewModels
{
    public class UserSignUpViewModel
    {
        public string UserName { get; set; } = null!;
        public string UserSurname { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string UserPasswordAgain { get; set; } = null!;

        public int RoleId { get; set; }
        
    }
}
