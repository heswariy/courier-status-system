using CourierStatusSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CourierStatusSystem.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Index()
        {
            List<Login> loginList = new List<Login>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44317/api/Login"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    loginList = JsonConvert.DeserializeObject<List<Login>>(apiResponse);
                }
            }
            return View(loginList);
        }

        [HttpGet]
        public ViewResult GetLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetLogin(string Username)
        {
            Login login = new Login();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44317/api/Login/" + Username))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    login = JsonConvert.DeserializeObject<Login>(apiResponse);
                }
            }
            return View(login);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateLogin(string username)
        {
            Login login = new Login();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44317/api/Login/" + username))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    login = JsonConvert.DeserializeObject<Login>(apiResponse);
                }
            }
            return View(login);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLogin(Login login)
        {
            Login receivedLogin = new Login();
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    var content = new MultipartFormDataContent();                    
                    content.Add(new StringContent(login.Username), "Username");
                    content.Add(new StringContent(login.Password), "Password");
                    using (var response = await httpClient.PutAsync("https://localhost:44317/api/Login", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ViewBag.Result = "Success";
                        receivedLogin = JsonConvert.DeserializeObject<Login>(apiResponse);
                    }
                }
            }
            return View(receivedLogin);
        }

    }
}
