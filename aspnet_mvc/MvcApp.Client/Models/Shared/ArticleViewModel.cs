namespace MvcApp.Client.Models.Author
{
    public class ArticleViewModel
    {
        public string Title { get; set; }

        public bool isPublished { get; set; }

        public ArticleViewModel(string title, bool publishedStatus)
        {
            Title = title;
            isPublished = publishedStatus;
        }

        // more to come
    }
}