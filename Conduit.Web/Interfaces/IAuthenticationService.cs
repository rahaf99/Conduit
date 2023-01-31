using Conduit.Web.JWT;
using Conduit.Web.Models;

namespace Conduit.Web.Interfaces
{
    public interface IAuthenticationService
    {
        public UserDto LogIn(usercred usercred);
        public string AddTokenToUser(int UserId, string finaltoken);


    }
}
