using AutoMapper;
using Conduit.Db.Entities;
using Conduit.Db.Interfaces;
using Conduit.Db;
using Conduit.Web.Interfaces;
using Conduit.Web.Models;

namespace Conduit.Web.Services
{
    public class FollowService:IFollowService
    {
        private readonly ConduitCoreDbContext _context;
        private readonly IFollowRepository _followRepository;
        private readonly IMapper _mapper;
        public FollowService(ConduitCoreDbContext context, IFollowRepository followRepository, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _followRepository = followRepository;
            _mapper = mapper;
        }
        public void CreateFollower(FollowDto followDto)
        {
            var follow = _mapper.Map<Follow>(followDto);
            _followRepository.CreateFollower(follow);
        }
    }
}
