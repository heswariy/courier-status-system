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
    
    public class LoginController : ControllerBase
    {
        private ILoginRepository loginRepository;

        public LoginController(ILoginRepository repo)
        {
            loginRepository = repo;
        }

        [HttpGet]
        public IEnumerable<Login> GetLogins()
        {
            return loginRepository.GetAllLogins().ToList();
        }

        [HttpGet("{Username}")]
        public Login GetLogin(string Username)
        {
            return loginRepository.GetLoginByUsername(Username);
        }

        [HttpPut]
        public Login Update([FromForm] Login login)
        {
            return loginRepository.UpdateLogin(login);
        }


    }
}
