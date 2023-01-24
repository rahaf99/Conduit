using Conduit.Db.Entities;

namespace Conduit.Web.Models
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
