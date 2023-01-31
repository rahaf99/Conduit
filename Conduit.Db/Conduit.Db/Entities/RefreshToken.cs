using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Entities
{
    public class RefreshToken
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public string refreshToken { get; set; }
        public bool IsActive { get; set; }
    }
}
