using Conduit.Db.Entities;
using Conduit.Db.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ConduitCoreDbContext _context;
        public CommentRepository(ConduitCoreDbContext context)
        {
            _context = context;
        }
        public void CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void DeleteComment(int CommentId)
        {
            Comment c = _context.Comments.Find(CommentId);
            _context.Comments.Remove(c);
            _context.SaveChanges();
        }

        public Comment GetCommentById(int CommentId)
        {
            Comment c = _context.Comments.Find(CommentId);
            return c;
        }
    }
}
