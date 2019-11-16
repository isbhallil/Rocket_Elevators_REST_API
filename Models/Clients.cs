using System;
using System.Collections.Generic;

namespace Rocket_REST_API.Models
{
    public partial class Clients
    {
        public long Id { get; set; }
        public string ImageSrc { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
