using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelpLocally.Domain;
using HelpLocally.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpLocally.Web.Pages.Companies
{
    public class DeleteModel : PageModel
    {
        private readonly CompanyService _companyService;

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        public DeleteModel(CompanyService companyService)
        {
            _companyService = companyService;
        }

        public IEnumerable<Company> Companies { get; set; }

        public async Task<ActionResult> OnGetAsync()
        {
            var company = await _companyService.GetEntityByIdAsync<Company>(Id);
            await _companyService.DeleteAsync(company);

            return Redirect("/");
        }
    }
}