using Entities.Abstract;
using System;

namespace Entities
{
    public class ArticleEntity : BaseEntity
    {
        public string Title { get; set;}
        public string Body { get; set; }
        public DateTime DateTime { get; set; }
        public string Link { get; set; }
    }
}
