using System;
using System.Collections.Generic;

namespace Rocket_REST_API.Models
{
    public partial class Interventions
    {
        public long Id { get; set; }
        public long AuthorId { get; set; }
        public long CustomerId { get; set; }
        public long BuildingId { get; set; }
        public long? BatteryId { get; set; }
        public long? ColumnId { get; set; }
        public long? ElevatorId { get; set; }
        public long EmployeeId { get; set; }
        public string InterventionBeginsAt { get; set; }
        public string InterventionFinishedAt { get; set; }
        public string Result { get; set; }
        public string Report { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Employees Author { get; set; }
    }
}
