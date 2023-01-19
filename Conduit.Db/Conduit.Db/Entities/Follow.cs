using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Entities
{
    public class Follow
    {
        [Required]
        public int FollowerId { get; set; }
        public User Follower { get; set; }
        [Required]
        public int FollowingId { get; set; }    
        public User Following { get; set; }
    
    }
}
