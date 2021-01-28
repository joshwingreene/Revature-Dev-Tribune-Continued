namespace MvcApp.Client.Controllers
{
  public class StarTrekController : Controller
  {
    private string apiUrl = "http://localhost:5555/";
    private HttpClient _http = new HttpClient();

    [HttpGet]
    public async IActionResult Get()
    {
      var response = await _http.GetAsync(apiUrl);

      if (response.IsSuccessCode)
      {
        var content = Json.Convert<HomeViewModel>(await response.Content.ReadStringAsync());

        return View("home", content);
      }
    }
  }
}
