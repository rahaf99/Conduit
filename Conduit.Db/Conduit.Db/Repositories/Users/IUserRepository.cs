﻿using Conduit.Db.Entities;
using Conduit.Db.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Repositories.Users
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
