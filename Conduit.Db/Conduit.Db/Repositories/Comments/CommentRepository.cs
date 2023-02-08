using Conduit.Db.Entities;
using Conduit.Db.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Repositories.Comments
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        private readonly ConduitCoreDbContext _context;
        public CommentRepository(ConduitCoreDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
