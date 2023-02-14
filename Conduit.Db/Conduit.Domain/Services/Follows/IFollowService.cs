using Conduit.Contracts.DTO;

namespace Conduit.Domain.Services.Follows
{
    public interface IFollowService
    {
        public void CreateFollower(FollowDto followDto);

    }
}
