using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using WebUI.Models;
using WebUI.Settings;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        string _baseUrl;

        public HomeController()
        {
            _baseUrl = Setting.BaseUrl;
        }

        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl + "Article/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseTask = await client.GetAsync(_baseUrl + "Article/GetArticle");

                if (responseTask.StatusCode == HttpStatusCode.OK)
                {
                    var readTask = JsonConvert.DeserializeObject<List<ArticleDetailDto>>(await responseTask.Content.ReadAsStringAsync());

                    return View(readTask);
                }
                else
                {
                    return View(new List<ArticleDetailDto>());
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ArticleListGetAll()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl + "Article/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseTask = await client.GetAsync(_baseUrl + "Article/GetArticle");

                if (responseTask.StatusCode == HttpStatusCode.OK)
                {
                    var readTask = JsonConvert.DeserializeObject<List<ArticleDetailDto>>(await responseTask.Content.ReadAsStringAsync());

                    return View("ArticleListGetByFilter", readTask);
                }
                else
                {
                    return View("ArticleListGetByFilter", new List<ArticleDetailDto>());
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ArticleListGetByTitle(string title)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl + "Article/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseTask = await client.GetAsync(_baseUrl + "Article/GetArticleByTitle?title=" + title);

                if (responseTask.StatusCode == HttpStatusCode.OK)
                {
                    var readTask = JsonConvert.DeserializeObject<List<ArticleDetailDto>>(await responseTask.Content.ReadAsStringAsync());

                    return View("ArticleListGetByFilter", readTask);
                }
                else
                {
                    return View("ArticleListGetByFilter", new List<ArticleDetailDto>());
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ArticleListGetByCategory(string category)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl + "Article/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseTask = await client.GetAsync(_baseUrl + "Article/GetArticleByCategory?category=" + category);

                if (responseTask.StatusCode == HttpStatusCode.OK)
                {
                    var readTask = JsonConvert.DeserializeObject<List<ArticleDetailDto>>(await responseTask.Content.ReadAsStringAsync());

                    return View("ArticleListGetByFilter", readTask);
                }
                else
                {
                    return View("ArticleListGetByFilter", new List<ArticleDetailDto>());
                }
            }
        }

        [Route("ArticleDetail/{articleId}", Name = "ArticleDetail")]
        public async Task<IActionResult> ArticleDetail(int articleId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl + "Article/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseTask = await client.GetAsync(_baseUrl + "Article/GetArticleById?articleId=" + articleId);

                if (responseTask.StatusCode == HttpStatusCode.OK)
                {
                    var readTask = JsonConvert.DeserializeObject<ArticleDetailDto>(await responseTask.Content.ReadAsStringAsync());

                    return View(readTask);
                }
                else
                {
                    return Redirect("/Home/Index");
                }
            }
        }

        [Authorize]
        public IActionResult AddArticle()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddArticle(AddArticleViewModel model)
        {
            #region Kategoriler
            List<ArticleCategory> articleCategories = new List<ArticleCategory>();
            if (!String.IsNullOrEmpty(model.Categories))
            {
                foreach (var item in model.Categories.Split(','))
                {
                    if (item.Trim() != "")
                    {
                        articleCategories.Add(new ArticleCategory()
                        {
                            Name = item.Trim(),
                        });
                    }
                }
            }
            #endregion

            ArticleAddDto add = new ArticleAddDto()
            {
                Article = new Article()
                {
                    Title = model.Title,
                    Contents = model.Contents,
                    CUser = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value),
                    Date = DateTime.Now
                },
                Categories = articleCategories
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl + "Article/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseTask = await client.PostAsJsonAsync(_baseUrl + "Article/AddArticle", add);

                if (responseTask.StatusCode == HttpStatusCode.OK)
                {
                    var readTask = JsonConvert.DeserializeObject<ArticleAddDto>(await responseTask.Content.ReadAsStringAsync());
                    return Ok(new SuccessResult(readTask.Article.Id.ToString()));
                }
                else
                {
                    return Ok(new ErrorResult("Makale oluşturulamadı!"));
                }
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(int articleId, string content)
        {
            Comment comment = new Comment()
            {
                ArticleId = articleId,
                Contents = content,
                CDate = DateTime.Now,
                CUser = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl + "Comment/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseTask = await client.PostAsJsonAsync(_baseUrl + "Comment/AddComment", comment);

                if (responseTask.StatusCode == HttpStatusCode.OK)
                {
                    return Ok(new SuccessResult());
                }
                else
                {
                    return Ok(new ErrorResult("Yorum ekleme işlemi hata ile sonuçlandı"));
                }
            }
        }
    }
}
