using AutoMapper;
using Conduit.Contracts.DTO;
using Conduit.Contracts.Exceptions;
using Conduit.Db;
using Conduit.Db.Entities;
using Conduit.Db.Repositories.Comments;
using Conduit.Db.Repositories.FavouriteArticles;

namespace Conduit.Domain.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
            _mapper = mapper;
        }

        /// <summary>
        /// Create new comment
        /// </summary>
        /// <param name="commentDto"></param>
        public void CreateComment(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            _commentRepository.Create(comment);
            _commentRepository.Save();
        }

        /// <summary>
        /// Delete an existing Comment
        /// </summary>
        /// <param name="CommentDtoId"></param>
        public void DeleteComment(int CommentDtoId)
        {
            if (CommentDtoId == 0)
            {
                throw new ArgumentNullException(nameof(CommentDtoId));
            }
            if (!_commentRepository.IsExist(CommentDtoId))
            {
                throw new Exception("Comment not exist!!");
            }
            _commentRepository.Delete(CommentDtoId);
            _commentRepository.Save();
        }

        /// <summary>
        /// Search Comment by CommentId
        /// </summary>
        /// <param name="CommentDtoId"></param>
        /// <returns></returns>
        public CommentDto GetCommentById(int CommentDtoId)
        {
            if (CommentDtoId == 0)
            {
                throw new ArgumentNullException(nameof(CommentDtoId));
            }
            if (!_commentRepository.IsExist(CommentDtoId))
            {
                throw new RecordNotFoundException("Comment not Found!!");
            }
            var comment = _commentRepository.GetById(CommentDtoId);
            var response = _mapper.Map<CommentDto>(comment);
            return response;

        }
    }
}
