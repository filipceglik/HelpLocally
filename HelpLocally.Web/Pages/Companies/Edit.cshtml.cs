using System;
using System.Threading.Tasks;
using HelpLocally.Domain;
using HelpLocally.Services;
using HelpLocally.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpLocally.Web.Pages
{
    public class EditModel : PageModel
    {
        private readonly CompanyService _companyService;

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CompanyViewModel Company { get; set; }

        public EditModel(CompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task OnGetAsync()
        {
            var company = await _companyService.GetEntityByIdAsync<Company>(Id);

            Company = new CompanyViewModel
            {
                Name = company.Name,
                Nip = company.Nip,
                BankAccountNumber = company.BankAccountNumber
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var company = await _companyService.GetEntityByIdAsync<Company>(Id);

            company.Name = Company.Name;
            company.Nip = Company.Nip;
            company.BankAccountNumber = Company.BankAccountNumber;

            await _companyService.SaveDbAsync();

            return Redirect("/Companies/List");
        }
    }
}
