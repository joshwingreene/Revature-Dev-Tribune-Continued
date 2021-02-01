// Username email password
using Microsoft.AspNetCore.Mvc;

namespace MvcApp.Client.Models.Reader
{
  [BindProperties]
    public class ReaderViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
