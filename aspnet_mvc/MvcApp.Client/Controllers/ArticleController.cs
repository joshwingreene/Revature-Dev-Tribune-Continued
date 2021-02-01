using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using MvcApp.Client.Models.Author;
using MvcApp.Client.Models.Shared;
using System.Collections.Generic;
using Newtonsoft.Json;
using MvcApp.Client.Models.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json.Serialization;

namespace MvcApp.Client.Controllers
{
    [Route("[controller]")]
    public class ArticleController : Controller
    {
        private string apiUrl = "https://localhost:5001/";
        private HttpClient _http;

        public ArticleController(){
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            _http = new HttpClient(clientHandler);
        }

        private string SerializeTopicViewModels(List<TopicViewModel> topicVMs)
        {
            return JsonConvert.SerializeObject(topicVMs);
        }

        private List<TopicViewModel> DeserializeTopicViewModels(object modelTempData)
        {
            return JsonConvert.DeserializeObject<List<TopicViewModel>>(modelTempData.ToString());
        }

        [HttpGet("show_article_creator")]
        public async Task<IActionResult> ShowArticleCreator()
        {
            // Get the topics
            var response = await _http.GetAsync(apiUrl + "Topic/topics");

            if (response.IsSuccessStatusCode)
            {
                var JsonResponse = await response.Content.ReadAsStringAsync();

                var TopicViewModels = JsonConvert.DeserializeObject<List<TopicViewModel>>(JsonResponse);

                List<SelectListItem> TopicSelectListItems = new List<SelectListItem>();

                foreach(var topic in TopicViewModels)
                {
                    TopicSelectListItems.Add(new SelectListItem(topic.Name, topic.Name));
                }

                var ArticleViewModel = new ArticleViewModel(TopicSelectListItems);

                //ViewBag.Topics = TopicSelectListItems;
                TempData["TopicVMs"] = SerializeTopicViewModels(TopicViewModels);

                return await Task.FromResult(View("ArticleCreator", ArticleViewModel));
            }
            return View("Error");
        }

        [HttpPost("create_article")]
        public IActionResult CreateArticle(ArticleViewModel articleVM)
        {
            // add the missing properties
            articleVM.isPublished = false;
            articleVM.ImagePath = "";
            //articleVM.PublishedDate = null;
            articleVM.EditedDate = DateTime.Now;
            //articleVM.Topic = new TopicViewModel("Big Data");
            articleVM.Author = new AuthorViewModel(3, "Joshwin Greene", "jg@aol.com", "12345");
            
            System.Console.WriteLine("Topic: " + articleVM.Topic);
            //System.Console.WriteLine("Topic Entity Id" + articleVM.Topic.EntityId);
            System.Console.WriteLine("Topic Name: " + articleVM.ChosenTopic);

            var TopicVMs = DeserializeTopicViewModels(TempData["TopicVMs"]);

            var ChosenTopicObject = TopicVMs.Find(t => t.Name == articleVM.ChosenTopic);

            System.Console.WriteLine("CreateArticle - Matched Topic Name: " + ChosenTopicObject.Name);

            articleVM.Topic = ChosenTopicObject;
            
            // prepare and make request
            _http.BaseAddress = new Uri(apiUrl + "Article/create_article");
            var postTask = _http.PostAsJsonAsync<ArticleViewModel>("create_article", articleVM);
            postTask.Wait();

            var result = postTask.Result;
            if(result.IsSuccessStatusCode)
            {
                return Content("Success");
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View("show_article_creator");
        }
    }
}