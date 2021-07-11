using System;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using HelpLocally.Domain;
using HelpLocally.Services;
using HelpLocally.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelpLocally.Web.Pages.Offers
{
    public class CreateModel : PageModel
    {
        private readonly OfferService _offerService;

        [BindProperty(SupportsGet = true)]
        public OfferViewModel Offer { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid UserId { get; set; } // user ID!

        [BindProperty]
        public Guid SelectedType { get; set; }
        public SelectList OfferTypes { get; set; }

        public CreateModel(OfferService offerService)
        {
            _offerService = offerService;

            var offerTypes = _offerService.GetOfferTypesDictionary();
            OfferTypes = new SelectList(offerTypes, "Key", "Value");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!PageContext.ModelState.IsValid)
            {
                var validator = new OfferViewModelValidator();
                var createCheck = validator.Validate(Offer);
                createCheck.AddToModelState(ModelState, nameof(Offer));

                return Page();
            }

           var company = await _offerService.GetUsersCompanyAsync(UserId);

            var offer = new Offer
            {
                Name = Offer.Name,
                Description = Offer.Description,
                Price = Offer.Price,
                OfferTypeId = SelectedType,
                CompanyId = company.Id
            };

            await _offerService.AddAsync(offer);

            return Redirect("/");
        }
    }
}