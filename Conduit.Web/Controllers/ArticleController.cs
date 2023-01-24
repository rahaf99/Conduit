using AutoMapper;
using Conduit.Web.Interfaces;
using Conduit.Web.Models;
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
        public ActionResult<IEnumerable<ArticleDto>> GetAllArticles()
        {
            var ArticlesFromRepository = _articleService.GetAllArticles();
            return new JsonResult(_mapper.Map<IEnumerable<ArticleDto>>(ArticlesFromRepository));
        }
        
         [HttpPost]
        public ActionResult<ArticleDto> CreateArticle(ArticleDto articleDto)
        {
             _articleService.CreateArticle(articleDto);
            return articleDto;
        }

        [HttpGet]
        public ActionResult<ArticleDto> GetArticleById(int ArticleDtoId)
        {
           return _articleService.GetArticleById(ArticleDtoId);
        }

        [HttpPut]
        public ActionResult<ArticleDto> UpdateArticle(ArticleDto articleDto)
        {
            _articleService.UpdateArticle(articleDto);
            return articleDto;
        }


        [HttpDelete]
        public void DeleteArticle(int ArticleDtoId)
        {
            _articleService.DeleteArticle(ArticleDtoId);
        }
    }
}
