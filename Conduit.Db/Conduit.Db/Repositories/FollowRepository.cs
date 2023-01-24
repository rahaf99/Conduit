using Conduit.Db.Entities;
using Conduit.Db.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Repositories
{
    public class FollowRepository:IFollowRepository
    {
        private readonly ConduitCoreDbContext _context;
        public FollowRepository(ConduitCoreDbContext context)
        {
            _context = context;
        }
        public void CreateFollower(Follow follow)
        {
            _context.Follows.Add(follow);
            _context.SaveChanges();
        }
    }
}
