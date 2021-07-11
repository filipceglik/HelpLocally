using FluentValidation;
using System;

namespace HelpLocally.Web.ViewModels
{
    public class OfferViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }

    public class OfferViewModelValidator : AbstractValidator<OfferViewModel>
    {
        public OfferViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Offer Name must not be empty");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Descritpion must not be empty");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price must not be empty");
        }
    }
}
