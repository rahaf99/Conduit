using AutoMapper;
using Conduit.Db;
using Conduit.Web.Models;
using Conduit.Db.Repositories.FavouriteArticles;
using Conduit.Db.Entities;

namespace Conduit.Web.Services.FavouriteArticles
{
    public class FavouriteArticleService : IFavouriteArticleService
    {
        private readonly ConduitCoreDbContext _context;
        private readonly IFavouriteArticleRepository _favouriteArticleRepository;
        private readonly IMapper _mapper;
        public FavouriteArticleService(ConduitCoreDbContext context, IFavouriteArticleRepository favouriteArticleRepository, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _favouriteArticleRepository = favouriteArticleRepository;
            _mapper = mapper;
        }
        public void CreateFavouriteArticle(FavouriteArticleDto favouriteArticleDto)
        {
            var favouriteArticle = _mapper.Map<FavouriteArticle>(favouriteArticleDto);
            _favouriteArticleRepository.CreateFavouriteArticle(favouriteArticle);
        }
    }
}
