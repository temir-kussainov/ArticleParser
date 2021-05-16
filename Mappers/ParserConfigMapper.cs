using Domain;
using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers
{
    public static class ParserConfigMapper
    {
        public static ParserConfigEntity ToEntity(this ParserConfig parserConfig)
        {
            if (parserConfig is null) return null;

            return new ParserConfigEntity
            {
                SiteLink = parserConfig.SiteLink,
                XPathArticles = parserConfig.XPathArticles,
                XPathLinkArticle = parserConfig.XPathLinkArticle,
                XPathTitle = parserConfig.XPathTitle,
                XPathBody = parserConfig.XPathBody,
                XPathDateTime = parserConfig.XPathDateTime,
                DateTimeFormat = parserConfig.DateTimeFormat
            };
        }

        public static ParserConfigEntity ToDomain(this ParserConfigModel parserConfig)
        {
            if (parserConfig is null) return null;

            return new ParserConfigEntity
            {
                SiteLink = parserConfig.SiteLink,
                XPathArticles = parserConfig.XPathArticles,
                XPathLinkArticle = parserConfig.XPathLinkArticle,
                XPathTitle = parserConfig.XPathTitle,
                XPathBody = parserConfig.XPathBody,
                XPathDateTime = parserConfig.XPathDateTime,
                DateTimeFormat = parserConfig.DateTimeFormat
            };
        }

        public static ParserConfig ToDomain(this ParserConfigEntity parserConfig)
        {
            if (parserConfig is null) return null;

            return new ParserConfig
            {
                SiteLink = parserConfig.SiteLink,
                XPathArticles = parserConfig.XPathArticles,
                XPathLinkArticle = parserConfig.XPathLinkArticle,
                XPathTitle = parserConfig.XPathTitle,
                XPathBody = parserConfig.XPathBody,
                XPathDateTime = parserConfig.XPathDateTime,
                DateTimeFormat = parserConfig.DateTimeFormat
            };
        }
    }
}
