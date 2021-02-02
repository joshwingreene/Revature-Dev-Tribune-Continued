using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StoreApi.Domain.Models;


namespace StoreApi.Service.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AuthorController:ControllerBase
  {
    private readonly RDTRepo _repo;
    public AuthorController(RDTRepo repository)
    {
      _repo = repository;
    }

    [HttpPost("AuthorLogin")]
    public async Task<IActionResult> GetAuthorIfValidCredential(Author author)
    {
      var r =_repo.GetAuthorIfValidCredential(author);
      return r!=null ? await Task.FromResult(Ok()): await Task.FromResult(BadRequest("Not able to log in the Author"));
    }
  }
}
