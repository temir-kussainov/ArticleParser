using Data.Repositories.Abstract;
using Domain;
using Mappers;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services
{
    public class ArticlesService : IArticlesService
    {
        private readonly IArticlesRepository _articlesRepository;
        public ArticlesService(IArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }

        public void AddArticle(Article article)
        {
            if (article is not null)
            {
                _articlesRepository.AddArticle(article.ToEntity());
            }
        }

        public void AddArticles(List<Article> articles)
        {
            if (articles.Count() > 0)
            {
                _articlesRepository.AddArticles(articles.ToEntities());
            }
        }

        public void DeleteArticleById(int id)
        {
            _articlesRepository.DeleteArticleById(id);
        }

        public Article GetArticleById(int id)
        {
            var article = _articlesRepository.GetArticleById(id);

            return article.ToDomain();
        }

        public void UpdateArticle(int id, Article article)
        {
            _articlesRepository.UpdateArticle(id, article.ToEntity());
        }

        public async Task<List<Article>> GetArticlesAsync(DateTime from, DateTime to)
        {
            var articles = await _articlesRepository.GetArticlesAsync(from, to);

            return articles.ToDomains();
        }

        public async Task<List<Article>> GetArticlesAsync(string text)
        {
            var articles = await _articlesRepository.GetArticlesAsync(text);

            return articles.ToDomains();
        }

        public async Task<List<ArticleTopWord>> GetArticlesTopWordsAsync(int count)
        {
            string strings = string.Empty;

            var articles = await _articlesRepository.GetArticlesAsync();

            var articlesBody = articles.Select(x => x.Body).ToList();

            foreach (string body in articlesBody)
            {
                strings += body;
            }

            string formattedString = Regex.Replace(strings, @"[^0-9a-zA-Zа-яёА-ЯЁ]+", ";");
            string[] words = formattedString.Split(';');

            var topWords = words.GroupBy(x => x)
               .Select(x => new ArticleTopWord(x.Key, x.Count()))
               .OrderByDescending(x => x.Count)
               .Take(count)
               .ToList();

            return topWords;
        }
    }
}
