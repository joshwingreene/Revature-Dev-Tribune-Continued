using System;
using StoreApi.Service.Models.Abstracts;

namespace StoreApi.Service.Models
{
    public class Article : AEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImagePath { get; set; }
        public bool IsPublished { get; set; }
        public Author ArticleAuthor { get; set; }
        public Topic ArticleTopic { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime EditeddDate { get; set; }
    }
}
