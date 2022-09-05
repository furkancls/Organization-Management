using Acitivity.ViewModels;
using Activities.Models;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Acitivity.Validators
{
    public class UserValidator : AbstractValidator<UserSignUpViewModel>
    {
        public UserValidator()
        {
            RuleFor(u => u.UserPassword).MinimumLength(8).WithMessage("En Az 8 karakterli olmalıdır")
                .Must(IsPasswordValid).WithMessage("Parolanız en az sekiz karakter, en az bir harf ve bir sayı içermelidir!")
            .Equal(u => u.UserPassword).WithMessage("Şifreler Eşleşmiyor");

            RuleFor(u => u.UserEmail).EmailAddress().WithMessage("Doğru bir şekilde email adresi veriniz")
                .When(u => !string.IsNullOrEmpty(u.UserEmail));
        }

        private bool IsPasswordValid(string arg)
        {
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            return regex.IsMatch(arg);
        }
    }
}