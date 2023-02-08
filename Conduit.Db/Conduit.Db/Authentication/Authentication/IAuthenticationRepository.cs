﻿using Conduit.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.AuthenticationAndRefresh.Authentication
{
    public interface IAuthenticationRepository
    {
        public bool DoesUserExist(int userId);
        public User GetUser(int userId);

    }
}
