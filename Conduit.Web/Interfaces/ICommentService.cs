﻿using Conduit.Db.Entities;
using Conduit.Web.Models;

namespace Conduit.Web.Interfaces
{
    public interface ICommentService
    {
        public void CreateComment(CommentDto commentDto);
        public CommentDto GetCommentById(int CommentDtoId);
        public void DeleteComment(int CommentDtoId);
    }
}
