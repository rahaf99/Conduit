using Conduit.Db.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Conduit.Db
{
    public class ConduitCoreDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<FavouriteArticle> FavouriteArticles { get; set; }

        public ConduitCoreDbContext(DbContextOptions<ConduitCoreDbContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer("Server=DESKTOP-D0JS7AA;Database=ConduitCore;Integrated Security=True;Trusted_Connection=True;Trust Server Certificate=true;");
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



            modelBuilder.Entity<User>().HasData
               (
               new User { UserId = 1, FirstName = "a1", LastName = "b1", UserName = "c1", Password = "hhh" },
               new User { UserId = 2, FirstName = "a2", LastName = "b2", UserName = "c2", Password = "hhh" },
               new User { UserId = 3, FirstName = "a3", LastName = "b3", UserName = "c3", Password = "hhh" },
               new User { UserId = 4, FirstName = "a4", LastName = "b4", UserName = "c4", Password = "hhh" },
               new User { UserId = 5, FirstName = "a5", LastName = "b5", UserName = "c5", Password = "hhh" },
               new User { UserId = 6, FirstName = "a6", LastName = "b6", UserName = "c6", Password = "hhh" },
               new User { UserId = 7, FirstName = "a7", LastName = "b7", UserName = "c7", Password = "hhh" },
               new User { UserId = 8, FirstName = "a8", LastName = "b8", UserName = "c8", Password = "hhh" }
               );



        }
    }
}