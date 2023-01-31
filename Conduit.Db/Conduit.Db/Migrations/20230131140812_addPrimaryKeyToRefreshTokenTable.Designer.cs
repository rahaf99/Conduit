﻿// <auto-generated />
using System;
using Conduit.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Conduit.Db.Migrations
{
    [DbContext(typeof(ConduitCoreDbContext))]
    [Migration("20230131140812_addPrimaryKeyToRefreshTokenTable")]
    partial class addPrimaryKeyToRefreshTokenTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Conduit.Db.Entities.Article", b =>
                {
                    b.Property<int>("ArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticleId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfLikes")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("Conduit.Db.Entities.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Conduit.Db.Entities.FavouriteArticle", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ArticleId");

                    b.HasIndex("ArticleId");

                    b.ToTable("FavouriteArticles");
                });

            modelBuilder.Entity("Conduit.Db.Entities.Follow", b =>
                {
                    b.Property<int>("FollowingId")
                        .HasColumnType("int");

                    b.Property<int>("FollowerId")
                        .HasColumnType("int");

                    b.HasKey("FollowingId", "FollowerId");

                    b.HasIndex("FollowerId");

                    b.ToTable("Follows");
                });

            modelBuilder.Entity("Conduit.Db.Entities.RefreshToken", b =>
                {
                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("refreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Conduit.Db.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            FirstName = "a1",
                            LastName = "b1",
                            Password = "hhh",
                            UserName = "c1"
                        },
                        new
                        {
                            UserId = 2,
                            FirstName = "a2",
                            LastName = "b2",
                            Password = "hhh",
                            UserName = "c2"
                        },
                        new
                        {
                            UserId = 3,
                            FirstName = "a3",
                            LastName = "b3",
                            Password = "hhh",
                            UserName = "c3"
                        },
                        new
                        {
                            UserId = 4,
                            FirstName = "a4",
                            LastName = "b4",
                            Password = "hhh",
                            UserName = "c4"
                        },
                        new
                        {
                            UserId = 5,
                            FirstName = "a5",
                            LastName = "b5",
                            Password = "hhh",
                            UserName = "c5"
                        },
                        new
                        {
                            UserId = 6,
                            FirstName = "a6",
                            LastName = "b6",
                            Password = "hhh",
                            UserName = "c6"
                        },
                        new
                        {
                            UserId = 7,
                            FirstName = "a7",
                            LastName = "b7",
                            Password = "hhh",
                            UserName = "c7"
                        },
                        new
                        {
                            UserId = 8,
                            FirstName = "a8",
                            LastName = "b8",
                            Password = "hhh",
                            UserName = "c8"
                        });
                });

            modelBuilder.Entity("Conduit.Db.Entities.Article", b =>
                {
                    b.HasOne("Conduit.Db.Entities.User", "User")
                        .WithMany("Articles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Conduit.Db.Entities.Comment", b =>
                {
                    b.HasOne("Conduit.Db.Entities.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Conduit.Db.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Conduit.Db.Entities.FavouriteArticle", b =>
                {
                    b.HasOne("Conduit.Db.Entities.Article", "Article")
                        .WithMany("FavoriteArticles")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Conduit.Db.Entities.User", "User")
                        .WithMany("FavouriteArticles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Conduit.Db.Entities.Follow", b =>
                {
                    b.HasOne("Conduit.Db.Entities.User", "Follower")
                        .WithMany("Following")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Conduit.Db.Entities.User", "Following")
                        .WithMany("Follower")
                        .HasForeignKey("FollowingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Follower");

                    b.Navigation("Following");
                });

            modelBuilder.Entity("Conduit.Db.Entities.Article", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("FavoriteArticles");
                });

            modelBuilder.Entity("Conduit.Db.Entities.User", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Comments");

                    b.Navigation("FavouriteArticles");

                    b.Navigation("Follower");

                    b.Navigation("Following");
                });
#pragma warning restore 612, 618
        }
    }
}
