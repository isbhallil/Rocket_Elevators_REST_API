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
    public class ElevatorsController : ControllerBase
    {
        private readonly database_developmentContext _context;

        public ElevatorsController(database_developmentContext context)
        {
            _context = context;
        }

        // GET: api/Elevators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Elevators>>> GetElevators(string status, int page, int perPage)
        {
            if (status != null)
            {
                if (page >= 0 && perPage > 0)
                {
                    return await _context.Elevators.Where(e => e.Status == status).Skip(page * perPage).Take(perPage).ToListAsync();
                };
                return await _context.Elevators.Where(e => e.Status == status).ToListAsync();
            }

            if (page >= 0 && perPage > 0)
            {
                Console.WriteLine("test =======================================");
                return await _context.Elevators.Skip(page * perPage).Take(perPage).ToListAsync();
            };

            return await _context.Elevators.ToListAsync();
        }

        // GET: api/Elevators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Elevators>> GetElevators(long id)
        {
            var elevators = await _context.Elevators.FindAsync(id);

            if (elevators == null)
            {
                return NotFound();
            }

            return elevators;
        }

        // PUT: api/Elevators/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<ActionResult<Elevators>> PutElevators(long id, string status)
        {
            Console.WriteLine("========================================");
            Console.WriteLine(status);

            if (status != null)
            {
                Elevators elevator = await _context.Elevators.FindAsync(id);
                if (elevator == null) return NotFound();

                elevator.Status = status;

                _context.Elevators.Update(elevator);
                _context.SaveChanges();

            };

            return await _context.Elevators.FindAsync(id);
        }

        // POST: api/Elevators
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Elevators>> PostElevators(Elevators elevators)
        {
            _context.Elevators.Add(elevators);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElevators", new { id = elevators.Id }, elevators);
        }

        // DELETE: api/Elevators/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Elevators>> DeleteElevators(long id)
        {
            var elevators = await _context.Elevators.FindAsync(id);
            if (elevators == null)
            {
                return NotFound();
            }

            _context.Elevators.Remove(elevators);
            await _context.SaveChangesAsync();

            return elevators;
        }

        private bool ElevatorsExists(long id)
        {
            return _context.Elevators.Any(e => e.Id == id);
        }
    }
}
