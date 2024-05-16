using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library_Management_System.Models;
using System;
using System.Collections.Generic;
using Library_Management_System.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Library_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatronController : ControllerBase
    {
        IPatron _patrons;
        public PatronController(IPatron patrons)
        {
            _patrons = patrons;
        }
        // GET /api/patrons: Retrieve a list of all patrons.
        [HttpGet]
        public IActionResult GetAllPatrons()
        {
            List<Patron> PatronList = _patrons.GetAllPatrons();

            return Ok(PatronList);
        }

        // GET /api/patrons/{id}: Retrieve details of a specific patron by ID.
        [HttpGet("{id}")]
        public IActionResult GetPatronById(int id)
        {
            Patron patron = _patrons.GetPatronById(id);
            return Ok(patron);
        }

        // POST /api/patrons: Add a new patron to the system.
        [HttpPost]
        [Authorize]
        public IActionResult AddPatron( Patron patron)
        {
            if (ModelState.IsValid == true)
            {
                _patrons.AddPatron(patron);
                _patrons.Save();
                return CreatedAtAction("GetByID", new { id = patron.ID }, patron);
            }
            return BadRequest(ModelState);
        }

        // PUT /api/patrons/{id}: Update an existing patron's information.
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdatePatron(int id)
        {
            Patron patron = _patrons.GetPatronById(id);
            if (patron != null)
            {
                _patrons.UpdatePatron(patron);
            }
            else
            {
                return BadRequest("Invalid Id");
            }
            return Ok(patron);
        }

        // DELETE /api/patrons/{id}: Remove a patron from the system.
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeletePatron(int id)
        {
            Patron patron = _patrons.GetPatronById(id);
            if (patron != null)
            {
                _patrons.DeletePatron(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        
    }
}
