using System;
using MvcApp.Client.Models.Author;
namespace MvcApp.Client.Models.Shared

{
    public class ArticleViewModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public AuthorViewModel Author { get; set; }
        public string ImagePath { get; set; }
        public TopicViewModel Topic { get; set; }
        public bool isPublished { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime EditedDate { get; set; }



    }
}
