using Microsoft.AspNetCore.Mvc;
using StoreApi.Domain.Models;

namespace StoreApi.Service.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ReaderController:ControllerBase
  {
    private readonly RDTRepo _repo;
    public ReaderController(RDTRepo repository)
    {
      _repo = repository;
    }

    [HttpPost("CreateReader")]
    public void CreateReader(Reader reader)
    {
      System.Console.WriteLine("CreateReader here");
      System.Console.WriteLine(reader.Email);
      _repo.CreateReader(reader);
    }

  }
}
