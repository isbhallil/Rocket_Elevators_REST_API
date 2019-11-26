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

        [HttpGet("info/entity={entity}&entityID={entityID}")]
        public async Task<ActionResult<Object>> GetInfo(string entity, long entityID)
        {
            Object entitySelected = null;

            if (entity == "elevator")
            {
                entitySelected = await _context.Elevators.FindAsync(entityID);
            }
            else if (entity == "column")
            {
                entitySelected = await _context.Columns.FindAsync(entityID);
            }
            else if (entity == "battery")
            {
                entitySelected = await _context.Batteries.FindAsync(entityID);
            }
            else if (entity == "intervention")
            {
                entitySelected = await _context.Interventions.FindAsync(entityID);
            }
            else if (entity == "employee")
            {
                entitySelected = await _context.Employees.FindAsync(entityID);
            }
            else if (entity == "customer")
            {
                entitySelected = await _context.Customers.FindAsync(entityID);
            }
            else if (entity == "building")
            {
                entitySelected = await _context.Buildings.FindAsync(entityID);
            }
            else if (entity == "address")
            {
                entitySelected = await _context.Addresses.FindAsync(entityID);
            };

            return entitySelected;
        }
    }
}
