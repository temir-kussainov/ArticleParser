using Data.Repositories.Abstract;
using Domain;
using Mappers;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ParsersConfigsService : IParsersConfigsService
    {
        private readonly IParsersConfigsRepository _parsersConfigsRepository;
        public ParsersConfigsService(IParsersConfigsRepository parsersConfigsRepository)
        {
            _parsersConfigsRepository = parsersConfigsRepository;
        }
        public void AddParserConfig(ParserConfig parserConfig)
        {
            if (parserConfig is not null)
            {
                _parsersConfigsRepository.AddParserConfig(parserConfig.ToEntity());
            }
        }

        public void DeleteParserConfigById(int id)
        {
            _parsersConfigsRepository.DeleteParserConfigById(id);
        }

        public ParserConfig GetParserConfigById(int id)
        {
            var article = _parsersConfigsRepository.GetParserConfigById(id);

            return article.ToDomain();
        }

        public void UpdateParserConfig(int id, ParserConfig parserConfig)
        {
            _parsersConfigsRepository.UpdateParserConfig(id, parserConfig.ToEntity());
        }
    }
}
