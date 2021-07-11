using System;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using HelpLocally.Domain;
using HelpLocally.Services;
using HelpLocally.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelpLocally.Web.Pages
{
    public class CreateModel : PageModel
    {
        private readonly CompanyService _companyService;

        [BindProperty(SupportsGet = true)]
        public CompanyViewModel Company { get; set; }


        [BindProperty]
        public Guid SelectedUser { get; set; }
        public SelectList Users { get; set; }

        public CreateModel(CompanyService companyService)
        {
            _companyService = companyService;

            var users = _companyService.GetUsersDictionary();
            Users = new SelectList(users, "Key", "Value");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!PageContext.ModelState.IsValid)
            {
                var validator = new CompanyViewModelValidator();
                var createCheck = validator.Validate(Company);
                createCheck.AddToModelState(ModelState, nameof(Company));

                return Page();
            }

            var company = new Company
            {
                Name = Company.Name,
                Nip = Company.Nip,
                BankAccountNumber = Company.BankAccountNumber,
                OwnerId = SelectedUser
            };

            await _companyService.AddAsync(company);

            return Redirect("/");
        }
    }
}
