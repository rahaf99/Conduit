using AutoMapper;
using Conduit.Web.Interfaces;
using Conduit.Web.Models;
using Conduit.Web.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Conduit.Web.Controllers
{
    [ApiController]
    [Route("api/Articles")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;
        public ArticleController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService ?? throw new ArgumentNullException(nameof(articleService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));    
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<ArticleDto>> GetAllArticles([FromQuery] ArticleParametersRequest articleParametersDto)
        {
            var ArticlesFromRepository = _articleService.GetAllArticles(articleParametersDto);
            return new JsonResult(_mapper.Map<IEnumerable<ArticleDto>>(ArticlesFromRepository));
        }

        [HttpPost]
        public ActionResult<ArticleDto> CreateArticle([FromBody] ArticleDto articleDto)
        {
            _articleService.CreateArticle(articleDto);
            return articleDto;
        }

        [HttpGet("{ArticleDtoId}")]
        public ActionResult<ArticleDto> GetArticleById(int ArticleDtoId)
        {
           return _articleService.GetArticleById(ArticleDtoId);
        }

        [HttpPut]
        public ActionResult<ArticleDto> UpdateArticle([FromBody]ArticleDto articleDto)
        {
            _articleService.UpdateArticle(articleDto);
            return articleDto;
        }


        [HttpDelete("{ArticleDtoId}")]
        public void DeleteArticle(int ArticleDtoId)
        {
            _articleService.DeleteArticle(ArticleDtoId);
        }
    }
}
