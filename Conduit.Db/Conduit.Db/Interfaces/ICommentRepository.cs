using Conduit.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Interfaces
{
    public interface ICommentRepository
    {
        public void CreateComment(Comment comment);
        public Comment GetCommentById(int CommentId);
        public void DeleteComment(int CommentId);
    }
}
