using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ParserConfigEntity : BaseEntity
    {
        public string SiteLink { get; set; }
        public string XPathArticles { get; set; }
        public string XPathLinkArticle { get; set; }

        public string XPathTitle { get; set; }
        public string XPathBody { get; set; }
        public string XPathDateTime { get; set; }
        public string DateTimeFormat { get; set; }
    }
}
