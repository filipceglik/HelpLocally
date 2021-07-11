using System.Collections.Generic;
using System.Threading.Tasks;
using HelpLocally.Domain;
using HelpLocally.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpLocally.Web.Pages.Offers
{
    public class IndexModel : PageModel
    {

        private readonly OfferService _offerService;

        public IndexModel(OfferService offerService)
        {
            _offerService = offerService;
        }

        public IEnumerable<Offer> Offers { get; set; }

        public async Task OnGetAsync()
        {
            var offers = await _offerService.GetAllAsync<Offer>();
            Offers = offers;

            System.Console.WriteLine();
        }
    }
}