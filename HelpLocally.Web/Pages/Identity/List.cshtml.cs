using System.Collections.Generic;
using System.Threading.Tasks;
using HelpLocally.Domain;
using HelpLocally.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpLocally.Web.Pages.Identity
{
    public class ListModel : PageModel
    {
        private readonly IdentityService _identityService;

        public ListModel(IdentityService identityService)
        {
            _identityService = identityService;
        }

        public IEnumerable<User> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _identityService.GetAllAsync<User>();
        }
    }
}