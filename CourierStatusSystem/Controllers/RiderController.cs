using CourierStatusSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CourierStatusSystem.Controllers
{
    public class RiderController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Rider> riderList = new List<Rider>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://heswariy-001-site1.dtempurl.com/api/Rider"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    riderList = JsonConvert.DeserializeObject<List<Rider>>(apiResponse);
                }
            }
            return View(riderList);
        }

        public ViewResult GetRider()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> GetRider(int riderId)
        {
            Rider rider = new Rider();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://heswariy-001-site1.dtempurl.com/api/Rider/" + riderId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    rider = JsonConvert.DeserializeObject<Rider>(apiResponse);
                }
            }
            return View(rider);
        }

        [HttpGet]
        public ViewResult AddRider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRider(Rider rider)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(rider), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("http://heswariy-001-site1.dtempurl.com/api/Rider", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        rider = JsonConvert.DeserializeObject<Rider>(apiResponse);
                    }
                }
                return View(rider);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRider(int riderId)
        {
            Rider rider = new Rider();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://heswariy-001-site1.dtempurl.com/api/Rider/" + riderId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    rider = JsonConvert.DeserializeObject<Rider>(apiResponse);
                }
            }
            return View(rider);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRider(Rider rider)
        {
            Rider receivedRider = new Rider();
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    var content = new MultipartFormDataContent();
                    content.Add(new StringContent(rider.riderId.ToString()), "riderId");
                    content.Add(new StringContent(rider.riderName), "riderName");
                    content.Add(new StringContent(rider.riderEmail), "riderEmail");
                    content.Add(new StringContent(rider.riderContact), "riderContact");
                    content.Add(new StringContent(rider.riderAddressLine1), "riderAddressLine1");
                    content.Add(new StringContent(rider.riderAddressLine2), "riderAddressLine2");
                    content.Add(new StringContent(rider.riderCity), "riderCity");
                    content.Add(new StringContent(rider.riderPostcode), "riderPostcode");
                    content.Add(new StringContent(rider.riderState), "riderState");
                    content.Add(new StringContent(rider.riderUsername), "riderUsername");
                    content.Add(new StringContent(rider.riderPassword), "riderPassword");
                    using (var response = await httpClient.PutAsync("http://heswariy-001-site1.dtempurl.com/api/Rider", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ViewBag.Result = "Success";
                        receivedRider = JsonConvert.DeserializeObject<Rider>(apiResponse);
                    }
                }
            }
            return View(receivedRider);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRider(int riderId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://heswariy-001-site1.dtempurl.com/api/Rider/" + riderId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
