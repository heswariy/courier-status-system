using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiderController : ControllerBase
    {
        private IRiderRepository riderRepository;

        public RiderController(IRiderRepository repo)
        {
            riderRepository = repo;
        }

        [HttpGet]
        public IEnumerable<Rider> GetRiders()
        {
            return riderRepository.GetAllRiders().ToList();
        }

        [HttpGet("{riderId}")]
        public Rider GetRiderById(int riderId)
        {
            return riderRepository.GetRiderById(riderId);
        }

        [HttpPost]
        public Rider Create([FromBody] Rider rider)
        {
            return riderRepository.AddRider(rider);
        }

        [HttpPut]
        public Rider Update([FromForm] Rider rider)
        {
            return riderRepository.UpdateRider(rider);
        }


        [HttpDelete("{riderId}")]
        public void Delete(int? riderId) => riderRepository.DeleteRider(riderId);


    }
}
