using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Okta.AspNetCore;

namespace MvcApp.Client.Controllers
{

    [Route("[controller]")]
    public class AuthorAccessController : Controller
    {
        public IActionResult SignIn()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Challenge(OktaDefaults.MvcAuthenticationScheme);
            }

            return RedirectToAction("ViewAuthorHome", "Author");
        }
        [HttpPost]
        public SignOutResult PostSignOut()
        {
            return new SignOutResult(
                new[]
                {
                OktaDefaults.MvcAuthenticationScheme,
                CookieAuthenticationDefaults.AuthenticationScheme,
             },
                new AuthenticationProperties { RedirectUri = "/" });
        }
    }
}
