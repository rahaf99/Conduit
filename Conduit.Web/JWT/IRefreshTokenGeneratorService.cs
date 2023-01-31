using Conduit.Db.Entities;

namespace Conduit.Web.JWT
{
    public interface IRefreshTokenGeneratorService
    {
        
        string GenerateToken (int userId);
        public RefreshTokenDto Refresh(int userId, string refreshToken);


    }
}
