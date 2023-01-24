using Conduit.Db.Entities;
using Conduit.Web.Models;

namespace Conduit.Web.Interfaces
{
    public interface IUserService
    {
        public void CreateUser(UserDto userDto);
        public UserDto GetUserById(int UserDtoId);
        public void UpdateUser(UserDto userDto);
    }
}
