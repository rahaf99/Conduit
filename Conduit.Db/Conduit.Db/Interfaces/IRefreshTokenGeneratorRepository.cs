using Conduit.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Interfaces
{
    public interface IRefreshTokenGeneratorRepository
    {
        public string GenerateToken(int userId);
       public RefreshToken Refresh(int userId, string refreshToken);

    }
}
