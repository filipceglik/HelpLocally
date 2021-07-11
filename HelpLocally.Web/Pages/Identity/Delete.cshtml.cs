using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelpLocally.Domain;
using HelpLocally.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpLocally.Web.Pages.Identity
{
    public class DeleteModel : PageModel
    {
        private readonly IdentityService _identityService;

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        public DeleteModel(IdentityService identityService)
        {
            _identityService = identityService;
        }

        public IEnumerable<User> Users { get; set; }

        public async Task<ActionResult> OnGetAsync()
        {
            var user = await _identityService.GetEntityByIdAsync<User>(Id);
            await _identityService.DeleteAsync(user);

            return Redirect("/");
        }
    }
}