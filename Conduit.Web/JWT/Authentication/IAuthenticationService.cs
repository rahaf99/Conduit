using Conduit.Web.JWT;
using Conduit.Web.Models;

namespace Conduit.Web.JWT.Authentication
{
    public interface IAuthenticationService
    {
        public bool DoesTheUserExist(int userId);
        public UserDto GetUser(int userId);


    }
}
