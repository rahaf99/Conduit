using Conduit.Db.Entities;
using System.ComponentModel.DataAnnotations;

namespace Conduit.Contracts.DTO
{
    public class FollowDto
    {
        [Required]
        public int FollowerId { get; set; }
        [Required]
        public int FollowingId { get; set; }
    }
}
