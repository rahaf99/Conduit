using Conduit.Db.Entities;
using System.ComponentModel.DataAnnotations;

namespace Conduit.Contracts.DTO
{
    public class FavouriteArticleDto
    {
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int ArticleId { get; set; }

    }
}
