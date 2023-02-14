using Azure.Identity;
using Conduit.Db.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Authentication.RefreshTokenGenerator
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
                    _user.RefreshedToken = RefreshToken;
                    _context.SaveChanges();
                }
                else
                {
                    RefreshToken refreshToken = new RefreshToken()
                    {
                        UserId = userId,
                       // Token = new Random().Next().ToString(),
                        RefreshedToken = RefreshToken
                    };
                    _context.RefreshTokens.Add(refreshToken);
                    _context.SaveChanges();
                }
                return RefreshToken;
            }
        }

        public RefreshToken TokenExists(int userId, string refreshToken)
        {
            return _context.RefreshTokens.FirstOrDefault(o => o.UserId == userId && o.RefreshedToken == refreshToken);
        }
        public RefreshToken DeleteToken(int userId)
        {
            var refreshToken = _context.RefreshTokens.FirstOrDefault(o => o.UserId == userId);
            if (refreshToken != null)
            {
                _context.RefreshTokens.Remove(refreshToken);
                _context.SaveChanges();
            }
            return refreshToken;
        }
    }
}
