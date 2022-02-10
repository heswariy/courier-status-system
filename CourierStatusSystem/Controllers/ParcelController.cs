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
    public class ParcelController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Parcel> parcelList = new List<Parcel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://heswariy-001-site1.dtempurl.com/api/Parcel"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    parcelList = JsonConvert.DeserializeObject<List<Parcel>>(apiResponse);
                }
            }
            return View(parcelList);
        }

        [HttpGet]
        public ViewResult GetParcel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetParcel(string trackingNum)
        {
            Parcel parcel = new Parcel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://heswariy-001-site1.dtempurl.com/api/Parcel/" + trackingNum))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    parcel = JsonConvert.DeserializeObject<Parcel>(apiResponse);
                }
            }
            return View(parcel);
        }

    }
}

