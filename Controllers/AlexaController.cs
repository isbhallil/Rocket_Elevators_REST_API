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
    public class AlexaController : ControllerBase
    {
        private readonly database_developmentContext _context;

        public AlexaController(database_developmentContext context)
        {
            _context = context;
        }

        // GET: api/Buildings
        [HttpGet("summary")]
        public async Task<ActionResult<AlexaSummary>> GetBuildings()
        {
            return new AlexaSummary()
            {
                elevatorsCount = await _context.Elevators.CountAsync(),
                buildingsCount = await _context.Buildings.CountAsync(),
                customerCount = await _context.Customers.CountAsync(),
                notRunningElevatorsCount = await _context.Elevators.Where(elevator => elevator.Status != "On" && elevator.Status != "Off").CountAsync(),
                batteriesCount = await _context.Batteries.CountAsync(),
                citiesCount = await _context.Addresses.GroupBy(p => p.City).CountAsync(),
                quotesAwaitingProccessing = await _context.Quotes.Where(quote => quote.CreatedAt > DateTime.Now.AddDays(-30)).CountAsync(),
                leadsInContactRequests = await _context.Leads.Where(lead => lead.CustomerId == null).CountAsync()
            };
        }
    }
}
