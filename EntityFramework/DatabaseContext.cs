using Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ArticleEntity> Articles { get; set; }
        public DbSet<ParserConfigEntity> ParsersConfigs { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TokenEntity> Tokens { get; set; }

        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region SEED DATA

            modelBuilder.Entity<UserEntity>().HasData(
              new UserEntity
              {
                  Id = 1,
                  FirstName = "Jon",
                  LastName = "Snow",
                  Login = "jon",
                  PasswordHash = "AQAAAAEAACcQAAAAEKOPbIyZyjFf6xY8FWjzMTOxW66msNg49k/41Z+z6TweZ6Ekl1Bn69HuEjKv1UWYgw==",
                  CreatedDate = DateTime.Now
              }
           );

           modelBuilder.Entity<ParserConfigEntity>().HasData(
             new ParserConfigEntity
             {
                 Id = 1,
                 SiteLink = "https://tengrinews.kz",
                 XPathArticles = "//div[@class='tn-main-news-item']",
                 XPathLinkArticle = "//a[@class='tn-link']",
                 XPathTitle = "//h1[@class='tn-content-title']",
                 XPathBody = "//div[@class='tn-news-content']",
                 XPathDateTime = "//h1[@class='tn-content-title']//span[@class='tn-hidden']",
                 CreatedDate = DateTime.Now,
                 DateTimeFormat = "dd M yyyy, HH:mm"
             },
              new ParserConfigEntity
              {
                  Id = 2,
                  SiteLink = "https://24.kz/ru/",
                  XPathArticles = "//div[@class='nspArt']",
                  XPathLinkArticle = "//a[@class='nspImageWrapper tleft fnull']",
                  XPathTitle = "//article[@class='view-article itemView']//div[@class='itemheader']//header//h1",
                  XPathBody = "//div[@class='itemBody']",
                  XPathDateTime = "//ul//li[@class='itemDate']//time",
                  CreatedDate = DateTime.Now,
                  DateTimeFormat = "HH:mm, dd.MM.yyyy"
              }
          );


            #endregion
        }
    }
}
