using Conduit.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Interfaces
{
    public interface IUserRepository
    {
        public void CreateUser(User user);
        public User GetUserById(int UserId);
        public void UpdateUser(User user);

    }
}
