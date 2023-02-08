using Conduit.Web.Models;

namespace Conduit.Web.Services.Follows
{
    public interface IFollowService
    {
        public void CreateFollower(FollowDto followDto);

    }
}
