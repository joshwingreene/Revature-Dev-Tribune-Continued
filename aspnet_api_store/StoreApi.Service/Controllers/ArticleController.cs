using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreApi.Domain.Models;

namespace StoreApi.Service.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ArticleController : ControllerBase
  {
    private RDTContext _ctx = new RDTContext();

    // [HttpGet("articles")]
    // public async Task<IActionResult> GetArticles()
    // {
    //   Article article = new Article();
    //   article.Author = repo.getN
    //   var articles = _ctx.Articles;
    //   _ctx = repo.getAuthor(articleID)
    //   Article art = new Article();
    //   art.Author = articles

    //   getAuthor(string)
    //   -ctx.Author.FirstOrDefault(s => s.EntityId == String)

    //   return await Task.FromResult(Ok(articles));

    // }
  }
}
