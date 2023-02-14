using Conduit.Contracts.DTO;

namespace Conduit.Contracts.JWT.Authentication
{
    public interface IAuthenticationService
    {
        public bool DoesUserExist(int userId);
        public UserDto GetUserById(int userId);


    }
}
