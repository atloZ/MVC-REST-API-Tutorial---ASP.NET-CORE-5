using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformDemo.Controllers
{
    [ApiController]
    public class TicketsController : ControllerBase
    {
        [HttpGet]
        [Route("api/tickets")]
        public IActionResult Get()
        {
            return Ok("Reading all the tickets");
        }

        [HttpGet]
        [Route("api/ticket/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Reading all the tickets #{id}");
        }

        [HttpPost]
        [Route("api/tickets")]
        public IActionResult Post()
        {
            return Ok("Creating a ticket");
        }

        [HttpPut]
        [Route("api/tickets")]
        public IActionResult Put()
        {
            return Ok("Update a ticket");
        }

        [HttpDelete]
        [Route("api/ticket")]
        public IActionResult Delete(int id)
        {
            return Ok($"Deleteing a ticket #{id}");
        }
    }
}
