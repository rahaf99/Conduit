using AutoMapper;
using Conduit.Db.Entities;
using Conduit.Db;
using Conduit.Web.Models;
using Conduit.Web.JWT;
using Conduit.Db.AuthenticationAndRefresh.Authentication;

namespace Conduit.Web.JWT.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ConduitCoreDbContext _context;
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IMapper _mapper;
        public AuthenticationService(ConduitCoreDbContext context, IAuthenticationRepository authenticationRepository, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _authenticationRepository = authenticationRepository;
            _mapper = mapper;
        }
        public bool DoesTheUserExist(int userId)
        {
            return _authenticationRepository.DoesUserExist(userId);
        }
        public UserDto GetUser(int userId)
        {
            var user = _authenticationRepository.GetUser(userId);
            var response = _mapper.Map<UserDto>(user);
            return response;
        }

    }
}
