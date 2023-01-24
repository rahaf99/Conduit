using Conduit.Web.Models;

namespace Conduit.Web.Interfaces
{
    public interface IFollowService
    {
        public void CreateFollower(FollowDto followDto);

    }
}
