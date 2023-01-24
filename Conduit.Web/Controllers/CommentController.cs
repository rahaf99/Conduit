using AutoMapper;
using Conduit.Db.Entities;
using Conduit.Web.Interfaces;
using Conduit.Web.Models;
using Conduit.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Conduit.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService ?? throw new ArgumentNullException(nameof(commentService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public ActionResult<CommentDto> CreateComment(CommentDto commentDto)
        {
            _commentService.CreateComment(commentDto);
            return commentDto;
        }

        [HttpGet]
        public ActionResult<CommentDto> GetCommentById(int CommentDtoId)
        {
            return _commentService.GetCommentById(CommentDtoId);
        }

        [HttpDelete]
        public void DeleteComment(int CommentDtoId)
        {
            _commentService.DeleteComment(CommentDtoId);
        }
    }
}
