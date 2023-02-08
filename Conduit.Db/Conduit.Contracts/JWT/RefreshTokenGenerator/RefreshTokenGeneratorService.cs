using AutoMapper;
using Conduit.Db;
using System.Security.Cryptography;
using Conduit.Db.Repositories;
using Conduit.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Conduit.Db.AuthenticationAndRefresh.RefreshTokenGenerator;
using Conduit.Web.JWT;

namespace Conduit.Web.JWT.RefreshTokenGenerator
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

        public RefreshTokenDto TokenExists(int userId, string refreshToken)
        {
            var RefreshToken = _refreshTokenGeneratorRepository.TokenExists(userId, refreshToken);
            var response = _mapper.Map<RefreshTokenDto>(RefreshToken);
            return response;
        }

        public RefreshTokenDto DeleteToken(int userId)
        {
            var RefreshToken = _refreshTokenGeneratorRepository.DeleteToken(userId);
            var response = _mapper.Map<RefreshTokenDto>(RefreshToken);
            return response;
        }


    }
}
