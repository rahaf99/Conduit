using AutoMapper;
using Conduit.Db;
using Conduit.Web.Models;
using Conduit.Db.Repositories.Follows;
using Conduit.Db.Entities;

namespace Conduit.Web.Services.Follows
{
    public class FollowService : IFollowService
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
