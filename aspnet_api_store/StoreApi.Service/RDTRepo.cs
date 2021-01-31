using StoreApi.Domain.Models; 
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;



namespace StoreApi.Service
{
    public class RDTRepo 
    {
        private RDTContext _ctx;
        //Constructor

        public RDTRepo(RDTContext context)
        {
            _ctx = context;
        }

        public IEnumerable<Topic> GetTopics()
        {
            return _ctx.Topics;
        }

        public IEnumerable<Article> GetArticlesByGivenTitle(string title)
        {
            return _ctx.Articles.Where(a => a.Title == title); 
        }

        public IEnumerable<Article>  GetArticles()
        {
            return _ctx.Articles; 
        }

        public IEnumerable<Article> GetArticlesByGivenEmail()
        {
            return null;
        }

        public void CreateArticle(Article article)
        {
            _ctx.Articles.Add(article); 
            _ctx.SaveChanges();
        }





        

    
    }
}