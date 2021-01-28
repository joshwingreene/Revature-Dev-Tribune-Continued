using System.Collections.Generic;

namespace StoreApi.Service.Models
{
  public class StarTrek
  {
    public int EntityId { get; set; }
    public List<Character> Characters { get; set; }
  }
}
