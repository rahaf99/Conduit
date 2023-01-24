using Conduit.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Interfaces
{
    public interface IFollowRepository
    {
        public void CreateFollower(Follow follow);

    }
}
