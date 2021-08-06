using Core.Models;
using DataStore.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public BugsContext db { get; set; }

        public ProjectsController(BugsContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Projects.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = db.Projects.Find(id);
            if (project == null)
                return NotFound();

            return Ok(project);
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
        public IActionResult GetProjectTicket(int pId)
        {
            var tickets = db.Tickets.Where(t => t.ProjektId == pId).ToList();

            if (tickets == null || tickets.Count <= null)
                return NotFound();

            return Ok(tickets);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Project project)
        {
            db.Projects.Add(project);
            db.SaveChanges();

            return CreatedAtAction(nameof(GetById),
                new { id = project.ProjcetId },
                project
                );
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Project project)
        {
            if (id != project.ProjcetId)
                return BadRequest();

            db.Entry(project).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch
            {
                if (db.Projects.Find(id) == null)
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var project = db.Projects.Find(id);
            if (project == null)
                return NotFound();

            db.Projects.Remove(project);
            db.SaveChanges();

            return Ok(project);
        }
    }
}
