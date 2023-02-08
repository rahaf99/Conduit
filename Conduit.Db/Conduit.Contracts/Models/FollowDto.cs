using Conduit.Db.Entities;

namespace Conduit.Web.Models
{
    public class FollowDto
    {
        public int FollowerId { get; set; }        
        public int FollowingId { get; set; }
    }
}
