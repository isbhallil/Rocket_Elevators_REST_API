using System;
using System.Collections.Generic;

namespace Rocket_REST_API.Models
{
    public partial class Awards
    {
        public long Id { get; set; }
        public string BuildingType { get; set; }
        public string BuildingName { get; set; }
        public string BuildingFile { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
