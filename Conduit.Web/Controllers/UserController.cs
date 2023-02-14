using AutoMapper;
using Conduit.Contracts.DTO;
using Conduit.Db.Entities;
using Conduit.Domain.Services.FavouriteArticles;
using Conduit.Domain.Services.Follows;
using Conduit.Domain.Services.Users;
using Conduit.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Conduit.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IFavouriteArticleService _favouriteArticleService;
        private readonly IFollowService _followService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IFavouriteArticleService favouriteArticleService,IFollowService followService, IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _favouriteArticleService = favouriteArticleService ?? throw new ArgumentException(nameof(favouriteArticleService));
            _followService = followService ?? throw new ArgumentException(nameof(followService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        
        [HttpPost]
        public ActionResult<UserDto> CreateUser(UserDto userDto)
        {
            if (userDto != null)
            {
                userDto.Password=BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            }
            _userService.CreateUser(userDto);
            return userDto;
        }

        [HttpGet("{UserDtoId}")]
        public ActionResult<UserDto> GetUserById(int UserDtoId)
        {
            return _userService.GetUserById(UserDtoId);
        }

        [HttpPut]
        public ActionResult<UserDto> UpdateUser(UserDto userDto)
        {
            _userService.UpdateUser(userDto);
            return userDto;
        }

        [HttpPost("FavouriteArticles")]
        public ActionResult<FavouriteArticleDto> CreateFavouriteArticle([FromBody] FavouriteArticleDto favouriteArticleDto)
        {
            _favouriteArticleService.CreateFavouriteArticle(favouriteArticleDto);
            return favouriteArticleDto;
        }

        [HttpPost("Follower")]
        public ActionResult<FollowDto> CreateFollower([FromBody] FollowDto followDto)
        {
            _followService.CreateFollower(followDto);
            return followDto;
        }
    }
}
