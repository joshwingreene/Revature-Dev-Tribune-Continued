using StoreApi.Service.Models.Abstracts;
using System.Collections.Generic;

namespace StoreApi.Service.Models
{
  public class Author : AUser
  {
    public string Name { get; set; }
    public List<Article> Articles { get; set; }
  }
}