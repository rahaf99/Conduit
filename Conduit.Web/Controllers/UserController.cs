﻿using AutoMapper;
using Conduit.Db.Entities;
using Conduit.Web.Interfaces;
using Conduit.Web.Models;
using Conduit.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Conduit.Web.Controllers
{
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
            _userService.CreateUser(userDto);
            return userDto;
        }

        [HttpGet]
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

        [HttpPost("{FavouriteArticle}")]
        public ActionResult<FavouriteArticleDto> CreateFavouriteArticle(FavouriteArticleDto favouriteArticleDto)
        {
            _favouriteArticleService.CreateFavouriteArticle(favouriteArticleDto);
            return favouriteArticleDto;
        }

        [HttpPost("{Follower}")]
        public ActionResult<FollowDto> CreateFollower(FollowDto followDto)
        {
            _followService.CreateFollower(followDto);
            return followDto;
        }
    }
}
