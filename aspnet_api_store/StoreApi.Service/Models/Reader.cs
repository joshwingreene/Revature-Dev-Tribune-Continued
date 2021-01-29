using StoreApi.Service.Models.Abstracts;
using System.Collections.Generic;

namespace StoreApi.Service.Models
{
  public class Reader : AUser
  {
    public string Username { get; set; }
    // If we have time, we can use in the client and repo
    public List<Topic> PreferredTopics { get; set; } 
  }
}