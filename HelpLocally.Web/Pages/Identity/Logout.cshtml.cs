using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpLocally.Web.Pages.Identity
{
    public class LogoutModel : PageModel
    {
        public async Task<ActionResult> OnGetAsync()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }
    }
}