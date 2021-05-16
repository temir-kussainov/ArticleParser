using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IArticlesService
    {
        void AddArticle(Article article);
        void UpdateArticle(int id, Article article);
        Article GetArticleById(int id);
        void DeleteArticleById(int id);
        void AddArticles(List<Article> articles);
        Task<List<Article>> GetArticlesAsync(DateTime from, DateTime to);
        Task<List<Article>> GetArticlesAsync(string text);
        Task<List<ArticleTopWord>> GetArticlesTopWordsAsync(int count);
    }
}
