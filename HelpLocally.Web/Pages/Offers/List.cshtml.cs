using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelpLocally.Domain;
using HelpLocally.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpLocally.Web.Pages.Offers
{
    public class ListModel : PageModel
    {
        private readonly OfferService _offerService;

        [BindProperty(SupportsGet = true)]
        public Guid UserId { get; set; }

        public ListModel(OfferService offerService)
        {
            _offerService = offerService;
        }

        public IEnumerable<Offer> Offers { get; set; }
        public Dictionary<Guid,string> Types { get; set; }
        public string type;

        public async Task OnGetAsync ()
        {
            var company = await _offerService.GetUsersCompanyAsync(UserId);
            Types = _offerService.GetOfferTypesDictionary();
            Offers = await _offerService.GetCompanyOffers(company.Id);
        }
    }
}