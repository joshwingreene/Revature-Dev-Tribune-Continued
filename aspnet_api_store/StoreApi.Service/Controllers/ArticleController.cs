using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreApi.Service.Models;

namespace StoreApi.Service.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class StarTrekController : ControllerBase
  {
    private StarTrekContext _ctx = new StarTrekContext();

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var chars = _ctx.StarTreks.FirstOrDefault();

      return await Task.FromResult(Ok(chars.Characters));

    }
  }
}
