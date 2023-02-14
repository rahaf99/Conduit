using AutoMapper;
using Conduit.Db.Entities;
using Conduit.Db;
using Conduit.Db.Authentication.Authentication;
using Conduit.Contracts.DTO;

namespace Conduit.Contracts.JWT.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IMapper _mapper;

        public AuthenticationService(IAuthenticationRepository authenticationRepository, IMapper mapper)
        {
            _authenticationRepository = authenticationRepository ?? throw new ArgumentNullException(nameof(authenticationRepository));
            _mapper = mapper;
        }

        public bool DoesUserExist(int userId)
        {
            if (userId == 0)
            {
                throw new ArgumentNullException(nameof(userId));
            }
            return _authenticationRepository.DoesUserExist(userId);
        }

        public UserDto GetUserById(int userId)
        {
            var user = _authenticationRepository.GetUserById(userId);
            var response = _mapper.Map<UserDto>(user);
            return response;
        }
    }
}
