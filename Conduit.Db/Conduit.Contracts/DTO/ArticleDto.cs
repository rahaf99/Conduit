using Conduit.Db.Entities;
using System.ComponentModel.DataAnnotations;

namespace Conduit.Contracts.DTO
{
    public class ArticleDto
    {
        public int ArticleId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public int NumberOfLikes { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}

