using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Abstract
{
    public interface IParsersConfigsRepository
    {
        void AddParserConfig(ParserConfigEntity parserConfigEntity);
        void UpdateParserConfig(int id, ParserConfigEntity parserConfigEntity);
        ParserConfigEntity GetParserConfigById(int id);
        void DeleteParserConfigById(int id);
    }
}
