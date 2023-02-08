using Conduit.Db.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.AuthenticationAndRefresh.Authentication
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ConduitCoreDbContext _context;
        public AuthenticationRepository(ConduitCoreDbContext context)
        {
            _context = context;
        }
        public bool DoesUserExist(int userId)
        {
            return _context.Users.Any(o => o.UserId == userId);
        }
        public User GetUser(int userId)
        {
            return _context.Users.FirstOrDefault(o => o.UserId == userId);
        }
    }
}
