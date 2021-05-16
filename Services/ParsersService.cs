using Domain;
using HtmlAgilityPack;
using Microsoft.AspNetCore.WebUtilities;
using Services.Abstract;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ParsersService : IParsersService
    {
        private ParserConfig _parserConfig;
        public async Task<List<Article>> ParseByConfigurationAsync(ParserConfig parserConfig)
        {
            _parserConfig = parserConfig;

            HtmlDocument articlesDoc = await LoadFromWebAsync(_parserConfig.SiteLink);

            IEnumerable<HtmlNode> nodesArticles = articlesDoc.DocumentNode.SelectNodes(_parserConfig.XPathLinkArticle)?.Take(30);

            List<Article> articles = new();

            if (nodesArticles is not null)
                foreach (HtmlNode nodeArticle in nodesArticles)
                {

                    string articlePath = nodeArticle?.GetAttributeValue("href", string.Empty);

                    var parsedArticle = await ParseArticleAsync(articlePath);

                    articles.Add(parsedArticle);
                }

            return articles;
        }

        private async Task<HtmlDocument> LoadFromWebAsync(string siteLink)
        {
            try
            {
                HtmlWeb htmlWeb = new();

                HtmlDocument htmlDocument = await htmlWeb.LoadFromWebAsync(siteLink);

                return htmlDocument;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private async Task<Article> ParseArticleAsync(string articlePath)
        {
            Article article = new();

            string articleLink = AbsoluteUrlString.Get(_parserConfig.SiteLink, articlePath);

            HtmlDocument articleDoc = await LoadFromWebAsync(articleLink);

            article.Link = articleLink;
            article.Title = articleDoc?.DocumentNode?.SelectSingleNode(_parserConfig.XPathTitle)?.InnerText;
            article.Body = articleDoc?.DocumentNode?.SelectSingleNode(_parserConfig.XPathBody)?.InnerText;
            string dateTimeStr = articleDoc?.DocumentNode.SelectSingleNode(_parserConfig.XPathDateTime)?.InnerText;

            if (!string.IsNullOrEmpty(dateTimeStr))
                article.DateTime = DateTimeFormatter.Format(dateTimeStr, _parserConfig.DateTimeFormat);

            return article;
        }
    }
}
