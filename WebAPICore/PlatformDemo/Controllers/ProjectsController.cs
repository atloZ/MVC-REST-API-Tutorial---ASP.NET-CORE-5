using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Reading all the projects");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Reading all the projects #{id}");
        }
        /// <summary>
        /// api/projekts/{pid}/tickets?tid{tid}
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/projekts/{pid}/tickets/{tid}")]
        public IActionResult GetProjectTicket(int pId, int tId)
        {
            return Ok("Creating a project");
        }
        
        [HttpPost]
        public IActionResult Post()
        {
            return Ok("Creating a project");
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok("Update a project");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Deleteing a project #{id}");
        }
    }
}
