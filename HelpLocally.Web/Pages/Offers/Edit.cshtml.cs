using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpLocally.Domain;
using HelpLocally.Services;
using HelpLocally.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpLocally.Web.Pages.Offers
{
    public class EditModel : PageModel
    {
        private readonly OfferService _offerService;

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public OfferViewModel Offer { get; set; }

        public EditModel(OfferService offerService)
        {
            _offerService = offerService;
        }

        public async Task OnGetAsync()
        {
            var offer = await _offerService.GetEntityByIdAsync<Offer>(Id);

            Offer = new OfferViewModel
            {
                Name = offer.Name,
                Description = offer.Description,
                Price = offer.Price,
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var offer = await _offerService.GetEntityByIdAsync<Offer>(Id);

            offer.Name = Offer.Name;
            offer.Description = Offer.Description;
            offer.Price = Offer.Price;

            await _offerService.SaveDbAsync();

            return Redirect("/");
        }
    }
}