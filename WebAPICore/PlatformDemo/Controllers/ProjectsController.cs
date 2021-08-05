using Microsoft.AspNetCore.Mvc;
using PlatformDemo.Models;
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
        /// api/projects/{pid}/tickets?tid{tid}
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //[Route("/api/projects/{pid}/tickets")]
        //public IActionResult GetProjectTicket([FromQuery]Ticket ticket)
        //{
        //    if (ticket == null) return BadRequest("Parameters are not provided property!");

            
        //    if (ticket.TicketId == 0)
        //        return Ok($"Reading all the tickets belong to projest #{ticket.ProjektId}");
        //    else
        //        return Ok($"Reading project #{ticket.ProjektId}, ticket #{ticket.TicketId}, title: {ticket.Title}, description: {ticket.Description}");
        //}

        [HttpGet]
        [Route("/api/projects/{pid}/tickets")]
        public IActionResult GetProjectTicket(int pId, [FromQuery] int tId)
        {
            if (tId == 0)
                return Ok($"Reading all the tickets belong to projest #{tId}");
            else
                return Ok($"Reading project #{pId}, ticket #{tId}");
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
