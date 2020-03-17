using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Contracts;

namespace CapstoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IRepositoryWrapper _repo;

        public HomeController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        // GET: api/School
        //[HttpGet]
        //public string Get()
        //{
        //}
    }
}
