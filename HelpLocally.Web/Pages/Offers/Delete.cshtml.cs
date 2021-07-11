using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelpLocally.Domain;
using HelpLocally.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpLocally.Web.Pages.Offers
{
    public class DeleteModel : PageModel
    {
        private readonly OfferService _offerService;

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        public DeleteModel(OfferService offerService)
        {
            _offerService = offerService;
        }

        public IEnumerable<Offer> Offers { get; set; }

        public async Task<ActionResult> OnGetAsync()
        {
            var offer = await _offerService.GetEntityByIdAsync<Offer>(Id);
            await _offerService.DeleteAsync(offer);

            return Redirect("/");
        }
    }
}