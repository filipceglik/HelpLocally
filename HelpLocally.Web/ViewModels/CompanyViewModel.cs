using FluentValidation;
using System;

namespace HelpLocally.Web.ViewModels
{
    public class CompanyViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Nip { get; set; }
        public string BankAccountNumber { get; set; }
    }

    public class CompanyViewModelValidator : AbstractValidator<CompanyViewModel>
    {
        public CompanyViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name field must not be empty");

            RuleFor(x => x.Nip)
                .NotEmpty().WithMessage("Nip field must not be empty")
                .MinimumLength(10).WithMessage("Nip field must contain at least 10 characters");

            RuleFor(x => x.BankAccountNumber)
                .NotEmpty().WithMessage("Bank account number field must not be empty")
                .MinimumLength(26).WithMessage("Bank account number field must contain at least 26 characters");
        }

        internal object Validate(OfferViewModel offer)
        {
            throw new NotImplementedException();
        }
    }
}
