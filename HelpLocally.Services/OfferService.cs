using HelpLocally.Domain;
using HelpLocally.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpLocally.Services
{
    public class OfferService : BaseService
    {
        public OfferService(HelpLocallyContext context) : base(context)
        {

        }

        public Dictionary<Guid, string> GetOfferTypesDictionary() => _context.OfferTypes.ToDictionary(y => y.Id, x => x.Name);

        public async Task<Company> GetUsersCompanyAsync(Guid userId)
        {
            return await _context.Companies.FirstOrDefaultAsync(x => x.OwnerId == userId);
        }

        public async Task<List<Offer>> GetCompanyOffers(Guid companyId)
        {
            return await _context.Offers.Where(x => x.CompanyId == companyId).ToListAsync();
        }
    }
}
