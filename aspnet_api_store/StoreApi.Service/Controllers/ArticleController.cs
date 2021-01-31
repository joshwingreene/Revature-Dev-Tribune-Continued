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
    private readonly RDTRepo _repo; 

    public ArticleController(RDTRepo repository)
    {
      _repo = repository;
    }

    [HttpGet("articles")]
    public async Task<IActionResult> GetArticle()
    {
      var Article = _repo.GetArticles();
      return await Task.FromResult(Ok(Article));
    }
  }
}
