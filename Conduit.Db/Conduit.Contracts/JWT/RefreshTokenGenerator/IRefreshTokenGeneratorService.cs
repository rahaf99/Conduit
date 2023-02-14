using Conduit.Db.Entities;

namespace Conduit.Contracts.JWT.RefreshTokenGenerator
{
    public interface IRefreshTokenGeneratorService
    {
        string GenerateToken(int userId);
        public RefreshTokenDto TokenExists(int userId, string refreshToken);
        public RefreshTokenDto DeleteToken(int userId);

    }
}
