using Conduit.Contracts.DTO;
using Conduit.Db.Entities;

namespace Conduit.Domain.Services.Comments
{
    public interface ICommentService
    {
        public void CreateComment(CommentDto commentDto);
        public CommentDto GetCommentById(int CommentDtoId);
        public void DeleteComment(int CommentDtoId);
    }
}
