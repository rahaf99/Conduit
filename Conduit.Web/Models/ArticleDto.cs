using Conduit.Db.Entities;

namespace Conduit.Web.Models
{
    public class ArticleDto
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int NumberOfLikes { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
