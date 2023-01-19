using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Entities
{
    public class Article
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int NumberOfLikes { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<FavouriteArticle> FavoriteArticles { get;set; }
    }
}
