using AutoMapper;
using Conduit.Db.Entities;
using Conduit.Db.Interfaces;
using Conduit.Db;
using Conduit.Web.Models;
using Conduit.Web.JWT;
using Conduit.Web.Interfaces;

namespace Conduit.Web.Services
{
    public class AuthenticationService: IAuthenticationService
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
        public UserDto LogIn(usercred usercred)
        {
            var user= _authenticationRepository.LogIn(usercred.UserId,usercred.Password);
            var response = _mapper.Map<UserDto>(user);
            return response;
        }
       public string AddTokenToUser(int UserId, string finaltoken)
        {
            return _authenticationRepository.AddTokenToUser(UserId,finaltoken);
        }
    }
}
