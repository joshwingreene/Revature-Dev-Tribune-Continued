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
  public class TopicController : ControllerBase
  {
    private RDTContext _ctx = new RDTContext();

    [HttpGet("topics")]
    public async Task<IActionResult> GetTopics()
    {
      var Topics = _ctx.Topics;

      return await Task.FromResult(Ok(Topics));
    }
  }
}















