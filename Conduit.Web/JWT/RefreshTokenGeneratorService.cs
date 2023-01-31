using AutoMapper;
using Conduit.Db.Interfaces;
using Conduit.Db;
using System.Security.Cryptography;
using Conduit.Db.Repositories;

namespace Conduit.Web.JWT
{
    public class RefreshTokenGeneratorService : IRefreshTokenGeneratorService
    {
        private readonly IRefreshTokenGeneratorRepository _refreshTokenGeneratorRepository;
        private readonly IMapper _mapper;
        public RefreshTokenGeneratorService(IRefreshTokenGeneratorRepository refreshTokenGeneratorRepository, IMapper mapper)
        {
            _refreshTokenGeneratorRepository = refreshTokenGeneratorRepository;
            _mapper = mapper;
        }
        public string GenerateToken(int userId)
        {
           return _refreshTokenGeneratorRepository.GenerateToken(userId);
             
        }
        
        public RefreshTokenDto Refresh(int userId, string refreshToken)
        {
            var RefreshToken = _refreshTokenGeneratorRepository.Refresh(userId, refreshToken);
            var response = _mapper.Map<RefreshTokenDto>(RefreshToken);
            return response;
        }
    }
}
