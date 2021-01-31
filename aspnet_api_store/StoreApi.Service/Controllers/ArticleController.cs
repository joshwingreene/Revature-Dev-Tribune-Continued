using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StoreApi.Domain.Models;

namespace StoreApi.Service.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ArticleController : ControllerBase
  {
    private readonly RDTRepo _repo;

    public ArticleController(RDTRepo repository)
    {
      _repo = repository;
    }

    [HttpGet("articles")]
    public async Task<IActionResult> GetArticle()
    {
      var Article = _repo.GetArticles();
      System.Console.WriteLine(Article);
      return await Task.FromResult(Ok(Article));
    }
    [HttpPost("create_article")]
    public async Task<IActionResult> CreateArticle(Article article)
    {
      _repo.CreateArticle(article);
      return await Task.FromResult(Ok());
    }
    [HttpPut("update_article")]
    public async Task<IActionResult> UpdateArticle(Article article)
    {
      _repo.UpdateArticle(article);
      return await Task.FromResult(Ok());
    }

    [HttpDelete("delete_article")]
    public async Task<IActionResult> DeleteArticle(Article article)
    {
      _repo.DeleteArticle(article);
      return await Task.FromResult(Ok());
    }

    [HttpGet("GetArticleTopic")]
    public async Task<IActionResult> GetArticlesByTopic(Topic topic)
    {
      var article = _repo.GetArticlesByTopic(topic);
      System.Console.WriteLine("Please Select a Topic");
      return await Task.FromResult(Ok(article));
    }

  }
}
