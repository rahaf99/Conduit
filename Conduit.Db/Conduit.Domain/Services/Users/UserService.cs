using AutoMapper;
using Conduit.Db;
using Conduit.Web.Models;
using Conduit.Db.Repositories;
using Conduit.Db.Repositories.Users;
using Conduit.Db.Entities;

namespace Conduit.Web.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ConduitCoreDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(ConduitCoreDbContext context, IUserRepository userRepository, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public void CreateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _userRepository.Create(user);
        }

        public UserDto GetUserById(int UserDtoId)
        {
            var user = _userRepository.GetById(UserDtoId);
            var response = _mapper.Map<UserDto>(user);
            return response;
        }

        public void UpdateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _userRepository.Update(user);
        }
    }
}
