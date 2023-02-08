using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<FavouriteArticle> FavouriteArticles { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public List<Follow> Follower { get; set; }
        public List<Follow> Following { get; set; }

    }
}
