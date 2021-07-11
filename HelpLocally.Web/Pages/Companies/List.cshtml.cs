using System.Collections.Generic;
using System.Threading.Tasks;
using HelpLocally.Domain;
using HelpLocally.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpLocally.Web.Pages.Companies
{
    public class ListModel : PageModel
    {
        private readonly CompanyService _companyService;

        public ListModel(CompanyService companyService)
        {
            _companyService = companyService;
        }

        public IEnumerable<Company> Companies { get; set; }

        public async Task OnGetAsync()
        {

            Companies = await _companyService.GetAllAsync<Company>();
        }
    }
}