using HelpLocally.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelpLocally.Services
{
    public class CompanyService : BaseService
    {
        public CompanyService(HelpLocallyContext context) : base(context)
        {

        }

        public Dictionary<Guid, string> GetUsersDictionary() => _context.Users.Where(x => x.Role == "Company").ToDictionary(y => y.Id, x => x.UserName);
    }
}
