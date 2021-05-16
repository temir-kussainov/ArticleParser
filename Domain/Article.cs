using System;
using System.Text.RegularExpressions;

namespace Domain
{
    public class Article
    {
        private string _body;
        private string _title;
        public string Title
        {
            get { return _title; }
            set => _title = Regex.Replace(value ?? "", @"\s+", " ");
        }
        public string Body
        {
            get { return _body; }
            set => _body = Regex.Replace(value ?? "", @"\s+", " ");
        }
        public DateTime DateTime { get; set; }
        public string Link { get; set; }
    }
}
