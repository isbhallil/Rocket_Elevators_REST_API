using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_REST_API.Models;

namespace Rocket_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterventionsController : ControllerBase
    {
        private readonly database_developmentContext _context;

        public InterventionsController(database_developmentContext context)
        {
            _context = context;
        }

        // GET: api/Interventions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interventions>>> GetInterventions(string elementType)
        {
            if (elementType == "elevator")
            {
                return await _context.Interventions.Where(i => i.ElevatorId != null).ToListAsync();
            }
            else if (elementType == "column")
            {
                return await _context.Interventions.Where(i => i.ColumnId != null).ToListAsync();
            }
            else if (elementType == "column")
            {
                return await _context.Interventions.Where(i => i.ColumnId != null).ToListAsync();
            }
            else if (elementType == "battery")
            {
                return await _context.Interventions.Where(i => i.BatteryId != null).ToListAsync();
            };

            return await _context.Interventions.ToListAsync();
        }

        [HttpGet("pendings")]
        public async Task<ActionResult<IEnumerable<Interventions>>> GetPendings()
        {
            var interventions = await _context.Interventions
            .Where(intervention => intervention.Status == "Pending" && intervention.InterventionBeginsAt == null).ToListAsync();


            if (interventions == null)
            {
                return NotFound();
            }

            return interventions;
        }

        // GET: api/Interventions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Interventions>> GetInterventions(long id)
        {
            var interventions = await _context.Interventions.FindAsync(id);

            if (interventions == null)
            {
                return NotFound();
            }

            return interventions;
        }

        // // GET: api/Interventions/{elementType}
        // [HttpGet("getByType/{elementType}")]
        // public async Task<List<Interventions>> GetInterventionsByType(String elementType)
        // {
        //     if (elementType == null) return null;

        //     if (elementType == "elevator")
        //     {
        //         return await _context.Interventions.Where(i => i.ElevatorId != null).ToListAsync();
        //     }
        //     else if (elementType == "column")
        //     {
        //         return await _context.Interventions.Where(i => i.ColumnId != null).ToListAsync();
        //     }
        //     else if (elementType == "column")
        //     {
        //         return await _context.Interventions.Where(i => i.ColumnId != null).ToListAsync();
        //     }
        //     else
        //     {
        //         return await _context.Interventions.Where(i => i.BatteryId != null).ToListAsync();
        //     };
        // }

        [HttpPut("{id}/inProgress")]
        public async Task<ActionResult<Interventions>> setInProgress(long id)
        {
            var intervention = await _context.Interventions.FindAsync(id);
            if (intervention == null) return NotFound();

            intervention.InterventionBeginsAt = DateTime.Now.ToString();
            intervention.Status = "InProgress";

            if (intervention.Status != "Completed")
            {
                _context.Interventions.Update(intervention);
                _context.SaveChanges();
            }


            return intervention;
        }

        [HttpPut("{id}/completed")]
        public async Task<ActionResult<Interventions>> setToCompleted(long id)
        {
            var intervention = await _context.Interventions.FindAsync(id);
            if (intervention == null) return NotFound();

            intervention.InterventionFinishedAt = DateTime.Now.ToString();
            intervention.Status = "Completed";

            if (intervention.Status == "InProgress")
            {
                _context.Interventions.Update(intervention);
                _context.SaveChanges();
            }

            return intervention;
        }

        // PUT: api/Interventions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterventions(long id, Interventions intervention)
        {
            if (id != intervention.Id)
            {
                return BadRequest();
            }

            _context.Entry(intervention).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterventionsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Interventions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Interventions>> PostInterventions(Interventions interventions)
        {
            _context.Interventions.Add(interventions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInterventions", new { id = interventions.Id }, interventions);
        }

        // GET: api/Interventions/element=battery&elementId=67&employeeId=51
        [HttpPost("element={element}&elementId={elementId}&employeeId={employeeId}")]
        public async Task<ActionResult<Interventions>> CreateIntervention(string element, long elementId, long employeeId)
        {
            Interventions intervention = new Interventions();

            if (element == "elevator")
            {
                Elevators elevator = await _context.Elevators.FindAsync(elementId);
                Columns column = await _context.Columns.FindAsync(elevator.ColumnId);
                Batteries battery = await _context.Batteries.FindAsync(column.BatteryId);
                Buildings building = await _context.Buildings.FindAsync(battery.BuildingId);
                Customers customer = await _context.Customers.FindAsync(building.CustomerId);

                intervention.CustomerId = customer.Id;
                intervention.BuildingId = building.Id;
                intervention.ElevatorId = elevator.Id;
                intervention.EmployeeId = employeeId;
                intervention.AuthorId = 51;
                intervention.Status = "Pending";
            }
            else if (element == "column")
            {
                Columns column = await _context.Columns.FindAsync(elementId);
                Batteries battery = await _context.Batteries.FindAsync(column.BatteryId);
                Buildings building = await _context.Buildings.FindAsync(battery.BuildingId);
                Customers customer = await _context.Customers.FindAsync(building.CustomerId);

                intervention.CustomerId = customer.Id;
                intervention.BuildingId = building.Id;
                intervention.ColumnId = elementId;
                intervention.EmployeeId = employeeId;
                intervention.AuthorId = 51;
                intervention.Status = "Pending";
            }
            else if (element == "battery")
            {
                Batteries battery = await _context.Batteries.FindAsync(elementId);
                Buildings building = await _context.Buildings.FindAsync(battery.BuildingId);
                Customers customer = await _context.Customers.FindAsync(building.CustomerId);

                intervention.CustomerId = customer.Id;
                intervention.BuildingId = building.Id;
                intervention.BatteryId = elementId;
                intervention.EmployeeId = employeeId;
                intervention.AuthorId = 51;
                intervention.Status = "Pending";
            };

            _context.Interventions.Add(intervention);
            await _context.SaveChangesAsync();

            return intervention;
        }

        // DELETE: api/Interventions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Interventions>> DeleteInterventions(long id)
        {
            var interventions = await _context.Interventions.FindAsync(id);
            if (interventions == null)
            {
                return NotFound();
            }

            _context.Interventions.Remove(interventions);
            await _context.SaveChangesAsync();

            return interventions;
        }

        public Interventions updateInterventionStatus(Interventions intervention, string status)
        {
            if (status == "Completed")
            {
                intervention.InterventionFinishedAt = DateTime.Now.ToString();
                intervention.Status = "Completed";
                if (intervention.Status == "InProgress") _context.Interventions.Update(intervention);
            }

            return intervention;
        }

        private bool InterventionsExists(long id)
        {
            return _context.Interventions.Any(e => e.Id == id);
        }
    }
}
