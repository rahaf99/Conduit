using Azure.Identity;
using Conduit.Db.Entities;
using Conduit.Db.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Repositories
{
    public class RefreshTokenGeneratorRepository : IRefreshTokenGeneratorRepository
    {
        private readonly ConduitCoreDbContext _context;
        public RefreshTokenGeneratorRepository(ConduitCoreDbContext context)
        {
            _context = context;
        }

        public string GenerateToken(int userId)
        {

            var randomnumber = new byte[32];
            using (var randomnumbergenerator = RandomNumberGenerator.Create())
            {
                randomnumbergenerator.GetBytes(randomnumber);
                string RefreshToken = Convert.ToBase64String(randomnumber);

                var _user = _context.RefreshTokens.FirstOrDefault(o => o.UserId == userId);
                if (_user != null)
                {
                    _user.refreshToken = RefreshToken;
                    _context.SaveChanges();
                }
                else
                {
                    RefreshToken refreshToken = new RefreshToken()
                    {
                        UserId = userId,
                        Token = new Random().Next().ToString(),
                        refreshToken = RefreshToken,
                        IsActive = true
                    };
                    _context.RefreshTokens.Add(refreshToken);
                    _context.SaveChanges();
                }
                return RefreshToken;
            }
        }

        public RefreshToken Refresh(int userId, string refreshToken)
        {
            return _context.RefreshTokens.FirstOrDefault(o => o.UserId == userId && o.refreshToken == refreshToken);
        }

    }
}
