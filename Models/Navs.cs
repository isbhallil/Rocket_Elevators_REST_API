using System;
using System.Collections.Generic;

namespace Rocket_REST_API.Models
{
    public partial class Navs
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string IdName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
