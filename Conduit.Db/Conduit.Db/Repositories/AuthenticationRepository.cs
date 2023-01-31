using Conduit.Db.Entities;
using Conduit.Db.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ConduitCoreDbContext _context;
        public AuthenticationRepository(ConduitCoreDbContext context)
        {
            _context = context;
        }
        public User LogIn(int userId, string password)
        {
            return _context.Users.FirstOrDefault(o => o.UserId== userId && o.Password == password);
        }
        public string AddTokenToUser(int UserId, string finaltoken)
        {
            var _user=_context.Users.FirstOrDefault(o => o.UserId == UserId);
            if (_user != null)
            {
                //_user.Token = finaltoken;
            }
            _context.SaveChanges();
            return finaltoken;
        }
    }
}
