using AutoMapper;
using Conduit.Db.Entities;
using Conduit.Web.Interfaces;
using Conduit.Web.Models;
using Conduit.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Conduit.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Comments")]
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
        public ActionResult<CommentDto> CreateComment([FromBody] CommentDto commentDto)
        {
            _commentService.CreateComment(commentDto);
            return commentDto;
        }

        [HttpGet("{CommentDtoId}")]
        public ActionResult<CommentDto> GetCommentById(int CommentDtoId)
        {
            return _commentService.GetCommentById(CommentDtoId);
        }

        [HttpDelete("{CommentDtoId}")]
        public void DeleteComment(int CommentDtoId)
        {
            _commentService.DeleteComment(CommentDtoId);
        }
    }
}
