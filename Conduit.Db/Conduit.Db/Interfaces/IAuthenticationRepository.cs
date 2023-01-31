using Conduit.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Interfaces
{
    public interface IAuthenticationRepository
    {
        public User LogIn(int userId, string password);
        public string AddTokenToUser(int UserId, string finaltoken);

    }
}
