using Conduit.Web.JWT;
using Conduit.Web.Models;

namespace Conduit.Web.Interfaces
{
    public interface IAuthenticationService
    {
        public bool DoesTheUserExist(int userId);
        public UserDto GetUser(int userId);


    }
}
