using Conduit.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Conduit.Db
{
    public class ConduitCoreDbContext :DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<FavouriteArticle> FavouriteArticles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-D0JS7AA;Database=ConduitCore;Integrated Security=True;Trusted_Connection=True;Trust Server Certificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Follow>().HasKey(k => new { k.FollowingId, k.FollowerId });
            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Follower)
                .WithMany(f => f.Following)
                .HasForeignKey(f => f.FollowerId);
            modelBuilder.Entity<Follow>()
               .HasOne(f => f.Following)
               .WithMany(f => f.Follower)
               .HasForeignKey(f => f.FollowingId);

            modelBuilder.Entity<FavouriteArticle>().HasKey(f => new { f.UserId , f.ArticleId });

        }
    }
}