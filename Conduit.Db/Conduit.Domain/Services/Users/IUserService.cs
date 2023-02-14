using Conduit.Contracts.DTO;
using Conduit.Db.Entities;

namespace Conduit.Domain.Services.Users
{
    public interface IUserService
    {
        public void CreateUser(UserDto userDto);
        public UserDto GetUserById(int UserDtoId);
        public void UpdateUser(UserDto userDto);
    }
}
