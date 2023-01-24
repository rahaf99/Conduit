using AutoMapper;
using Conduit.Db;
using Conduit.Db.Entities;
using Conduit.Db.Interfaces;
using Conduit.Web.Interfaces;
using Conduit.Web.Models;

namespace Conduit.Web.Services
{
    public class CommentService : ICommentService
    {
        private readonly ConduitCoreDbContext _context;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public CommentService(ConduitCoreDbContext context, ICommentRepository commentRepository, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public void CreateComment(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            _commentRepository.CreateComment(comment);
        }

        public void DeleteComment(int CommentDtoId)
        {
            _commentRepository.DeleteComment(CommentDtoId);
        }

        public CommentDto GetCommentById(int CommentDtoId)
        {
           var comment = _commentRepository.GetCommentById(CommentDtoId);
           var response = _mapper.Map<CommentDto>(comment);
            return response;

        }
    }
}
