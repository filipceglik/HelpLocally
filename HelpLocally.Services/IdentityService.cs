using HelpLocally.Domain;
using HelpLocally.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpLocally.Services
{
    public class IdentityService : BaseService
    {
        public IdentityService(HelpLocallyContext context) : base(context)
        {

        }

        public Role[] GetRoles() => _context.Roles.ToArray();

        public Dictionary<Guid, string> GetRolesDictionary() => _context.Roles.ToDictionary(y => y.Id, x => x.Name);

        public async Task TryRegisterAsync(string userName, string userPassword, Guid userRole)
        {
            if (!await _context.Users.AnyAsync(x => x.UserName == userName))
            {
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(userPassword);
                var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == userRole);

                var user = new User(userName, passwordHash, role.Name);

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }

            // no user in db
        }

        public async Task<(bool, User)> Authenticate(string userName, string userPassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            if (user is { })
            {
                if(BCrypt.Net.BCrypt.Verify(userPassword, user.PasswordHash))
                {
                    return (true, user);
                }
            }
            return (false, null); // no user in db
        }
    }
}
