using FluentValidation;

namespace HelpLocally.Web.ViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username must not be empty");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password must not be empty")
                .MinimumLength(5).WithMessage("Password must contain at least 5 characters");
        }
    }
}
