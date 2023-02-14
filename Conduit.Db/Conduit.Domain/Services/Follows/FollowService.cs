using AutoMapper;
using Conduit.Db;
using Conduit.Db.Repositories.Follows;
using Conduit.Db.Entities;
using Conduit.Contracts.DTO;

namespace Conduit.Domain.Services.Follows
{
    public class FollowService : IFollowService
    {
        private readonly IFollowRepository _followRepository;
        private readonly IMapper _mapper;
        public FollowService(IFollowRepository followRepository, IMapper mapper)
        {
            _followRepository = followRepository ?? throw new ArgumentNullException(nameof(followRepository));
            _mapper = mapper;
        }

        /// <summary>
        /// Create follower
        /// </summary>
        /// <param name="followDto"></param>
        public void CreateFollower(FollowDto followDto)
        {
            var follow = _mapper.Map<Follow>(followDto);
            _followRepository.CreateFollower(follow);
        }
    }
}
