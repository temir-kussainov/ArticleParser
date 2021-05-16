using Data.Repositories.Abstract;
using Entities;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ArticlesRepository : IArticlesRepository
    {
        private readonly DatabaseContext _databaseContext;
        public ArticlesRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void AddArticle(ArticleEntity articleEntity)
        {
            if (articleEntity is not null)
            {
                _databaseContext.Articles.Add(articleEntity);
                _databaseContext.SaveChanges();
            }
        }

        public void AddArticles(List<ArticleEntity> articleEntities)
        {
            if (articleEntities.Count() > 0)
            {
                _databaseContext.Articles.AddRange(articleEntities);
                _databaseContext.SaveChanges();
            }
        }

        public void DeleteArticleById(int id)
        {
            ArticleEntity article = GetArticleById(id);

            if (article is not null)
            {
                _databaseContext.Articles.Remove(article);
                _databaseContext.SaveChanges();
            }
        }

        public ArticleEntity GetArticleById(int id)
        {
            ArticleEntity article = _databaseContext.Articles.FirstOrDefault(x => x.Id.Equals(id));

            return article;
        }

        public void UpdateArticle(int id, ArticleEntity articleEntity)
        {
            ArticleEntity article = GetArticleById(id);

            if (article is not null)
            {
                article.Title = articleEntity.Title;
                article.Body = articleEntity.Body;
                article.DateTime = articleEntity.DateTime;
                article.UpdatedDate = DateTime.Now;

                _databaseContext.SaveChanges();
            }
        }

        public async Task<List<ArticleEntity>> GetArticlesAsync(DateTime from, DateTime to)
        {
            List<ArticleEntity> articles = await _databaseContext.Articles
                .Where(x => x.DateTime >= from && x.DateTime <= to)
                .ToListAsync();

            return articles;
        }

        public async Task<List<ArticleEntity>> GetArticlesAsync(string text)
        {
            List<ArticleEntity> articles = await _databaseContext.Articles
                .Where(x => x.Body.Contains(text))
                .ToListAsync();

            return articles;
        }

        public async Task<List<ArticleEntity>> GetArticlesAsync()
        {
            List<ArticleEntity> articles = await _databaseContext.Articles
                .ToListAsync();

            return articles;
        }

    }
}
