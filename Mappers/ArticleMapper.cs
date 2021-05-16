using Domain;
using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mappers
{
    public static class ArticleMapper
    {
        public static ArticleEntity ToEntity(this Article article)
        {
            if (article is null) return null;

            return new ArticleEntity
            {
                Title = article.Title,
                Body = article.Body,
                DateTime = article.DateTime,
                Link = article.Link
            };
        }

        public static List<ArticleEntity> ToEntities(this List<Article> articles)
        {
            return articles.Select(article => new ArticleEntity()
            {
                Title = article.Title,
                Body = article.Body,
                DateTime = article.DateTime,
                Link = article.Link
            }).ToList();

        }
       
        public static Article ToDomain(this ArticleModel article)
        {
            if (article is null) return null;

            return new Article
            {
                Title = article.Title,
                Body = article.Body,
                DateTime = article.DateTime,
                Link = article.Link
            };
        }

        public static List<Article> ToDomains(this List<ArticleEntity> articles)
        {
            return articles.Select(article => new Article()
            {
                Title = article.Title,
                Body = article.Body,
                DateTime = article.DateTime,
                Link = article.Link
            }).ToList();
        }

        public static Article ToDomain(this ArticleEntity article)
        {
            if (article is null) return null;

            return new Article
            {
                Title = article.Title,
                Body = article.Body,
                DateTime = article.DateTime,
                Link = article.Link
            };
        }
    }
}
