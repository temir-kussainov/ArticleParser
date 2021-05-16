using Data.Repositories.Abstract;
using Entities;
using EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ParsersConfigsRepository : IParsersConfigsRepository
    {
        private readonly DatabaseContext _databaseContext;
        public ParsersConfigsRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public void AddParserConfig(ParserConfigEntity parserConfigEntity)
        {
            if (parserConfigEntity is not null)
            {
                _databaseContext.ParsersConfigs.Add(parserConfigEntity);
                _databaseContext.SaveChanges();
            }
        }

        public void DeleteParserConfigById(int id)
        {
            ParserConfigEntity parserConfig = GetParserConfigById(id);

            if (parserConfig is not null)
            {
                _databaseContext.ParsersConfigs.Remove(parserConfig);
                _databaseContext.SaveChanges();
            }
        }

        public ParserConfigEntity GetParserConfigById(int id)
        {
            ParserConfigEntity parserConfig = _databaseContext.ParsersConfigs.FirstOrDefault(x => x.Id.Equals(id));

            return parserConfig;
        }

        public void UpdateParserConfig(int id, ParserConfigEntity parserConfigEntity)
        {
            ParserConfigEntity parserConfig = GetParserConfigById(id);

            if (parserConfig is not null)
            {
                parserConfig.SiteLink = parserConfigEntity.SiteLink;
                parserConfig.XPathArticles = parserConfigEntity.XPathArticles;
                parserConfig.XPathLinkArticle = parserConfigEntity.XPathLinkArticle;
                parserConfig.XPathTitle = parserConfigEntity.XPathTitle;
                parserConfig.XPathBody = parserConfigEntity.XPathBody;
                parserConfig.XPathDateTime = parserConfigEntity.XPathDateTime;

                parserConfig.UpdatedDate = DateTime.Now;

                _databaseContext.SaveChanges();
            }
        }
    }
}
