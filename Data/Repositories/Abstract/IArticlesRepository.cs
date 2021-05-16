using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Abstract
{
    public interface IArticlesRepository
    {
        void AddArticle(ArticleEntity articleEntity);
        void UpdateArticle(int id, ArticleEntity articleEntity);
        ArticleEntity GetArticleById(int id);
        void DeleteArticleById(int id);
        void AddArticles(List<ArticleEntity> articleEntities);
        Task<List<ArticleEntity>> GetArticlesAsync(DateTime from, DateTime to);
        Task<List<ArticleEntity>> GetArticlesAsync(string text);
        Task<List<ArticleEntity>> GetArticlesAsync();
    }
}
