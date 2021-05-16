using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IParsersConfigsService
    {
        void AddParserConfig(ParserConfig parserConfig);
        void UpdateParserConfig(int id, ParserConfig parserConfig);
        ParserConfig GetParserConfigById(int id);
        void DeleteParserConfigById(int id);
    }
}
