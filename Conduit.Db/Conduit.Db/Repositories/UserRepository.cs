using Conduit.Db.Entities;
using Conduit.Db.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly ConduitCoreDbContext _context;
        public UserRepository(ConduitCoreDbContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUserById(int UserId)
        {
            User u = _context.Users.Find(UserId);
            return u;
        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}
