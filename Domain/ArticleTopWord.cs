using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ArticleTopWord
    {
        public string Word { get; set; }
        public int Count { get; set; }

        public ArticleTopWord(string word, int count)
        {
            Word = word;
            Count = count;
        }
    }
}
