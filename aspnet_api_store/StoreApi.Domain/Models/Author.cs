using StoreApi.Domain.Models.Abstracts;
using System.Collections.Generic;

namespace StoreApi.Domain.Models
{
  public class Author : AUser
  {
    public string Name { get; set; }
    public List<Article> Articles { get; set; }
  }
}