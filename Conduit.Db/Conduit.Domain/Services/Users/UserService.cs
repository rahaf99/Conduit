using AutoMapper;
using Conduit.Db;
using Conduit.Db.Repositories;
using Conduit.Db.Repositories.Users;
using Conduit.Db.Entities;
using Conduit.Contracts.DTO;
using Conduit.Contracts.Exceptions;

namespace Conduit.Domain.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper;
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="userDto"></param>
        public void CreateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _userRepository.Create(user);
            _userRepository.Save();
        }

        /// <summary>
        /// Search user by userId
        /// </summary>
        /// <param name="UserDtoId"></param>
        /// <returns></returns>
        public UserDto GetUserById(int UserDtoId)
        {
            if (UserDtoId == 0)
            {
                throw new ArgumentNullException(nameof(UserDtoId));
            }
            if (!_userRepository.IsExist(UserDtoId))
            {
                throw new RecordNotFoundException("User not Found!!");
            }
            var user = _userRepository.GetById(UserDtoId);
            var response = _mapper.Map<UserDto>(user);
            return response;
        }

        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <param name="userDto"></param>
        public void UpdateUser(UserDto userDto)
        {
            if (userDto == null || userDto.UserId == 0)
            {
                throw new ArgumentNullException(nameof(userDto));
            }
            var user = _mapper.Map<User>(userDto);
            if (!_userRepository.IsExist(user.UserId))
            {
                throw new RecordNotFoundException("User not exist!!");
            }
            _userRepository.Update(user);
            _userRepository.Save(); 
        }
    }
}
