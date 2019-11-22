using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_REST_API.Models;

namespace Rocket_REST_API.Models
{
    public  class AlexaSummary
    {
        public AlexaSummary()
        {

        }
            public int elevatorsCount {get; set;}
            public int buildingsCount {get; set;}
            public int customerCount {get; set;}
            public int notRunningElevatorsCount {get; set;}
            public int batteriesCount {get; set;}
            public int citiesCount {get; set;}
            public int quotesAwaitingProccessing {get; set;}
            public int leadsInContactRequests {get; set;}

    }
}
