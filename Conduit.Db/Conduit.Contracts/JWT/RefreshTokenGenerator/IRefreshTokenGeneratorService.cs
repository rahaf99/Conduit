using Conduit.Db.Entities;
using Conduit.Web.JWT;

namespace Conduit.Web.JWT.RefreshTokenGenerator
{
    public interface IRefreshTokenGeneratorService
    {
        string GenerateToken(int userId);
        public RefreshTokenDto TokenExists(int userId, string refreshToken);
        public RefreshTokenDto DeleteToken(int userId);

    }
}
