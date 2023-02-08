using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Entities
{
    public class FavouriteArticle
    {
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public int ArticleId { get; set; }
        public Article Article { get; set; }

    }
}
