using Conduit.Db.Entities;
using System.ComponentModel.DataAnnotations;

namespace Conduit.Contracts.DTO
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        [Required]
        public int PostedBy { get; set; }
        [Required]
        public int ArticleId { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
