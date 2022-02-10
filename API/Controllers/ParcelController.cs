using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ParcelController : ControllerBase
    {
        private IParcelRepository parcelRepository;

        public ParcelController(IParcelRepository repo)
        {
            parcelRepository = repo;
        }

        [HttpGet]
        public IEnumerable<Parcel> GetParcels()
        {
            return parcelRepository.GetAllParcels().ToList();
        }

        [HttpGet("{trackingNum}")]
        public Parcel GetParcel(string trackingNum)
        {
            return parcelRepository.GetParcelByTrackingNum(trackingNum);
        }
    }
}
