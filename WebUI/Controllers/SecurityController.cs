using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
using WebUI.Settings;

namespace WebUI.Controllers
{
    public class SecurityController : Controller
    {
        string _baseUrl;

        public SecurityController()
        {
            _baseUrl = Setting.BaseUrl;
        }

        public IActionResult Login()
        {
            return View(new UserForLoginDto());
        }

        [HttpPost]
        public async Task<JsonResult> Login(UserForLoginDto userForLoginDto)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl + "User/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseTask = await client.PostAsJsonAsync(
                    _baseUrl + "User/Login", userForLoginDto);

                if (responseTask.StatusCode == HttpStatusCode.OK)
                {
                    var readTask = JsonConvert.DeserializeObject<User>(await responseTask.Content.ReadAsStringAsync());

                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, readTask.Id.ToString()));

                    var useridentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);

                    await HttpContext.SignInAsync(principal);

                    return Json(new SuccessResult());
                }
                else
                {
                    return Json(new ErrorResult(await responseTask.Content.ReadAsStringAsync()));
                }
            }
        }
    }
}
