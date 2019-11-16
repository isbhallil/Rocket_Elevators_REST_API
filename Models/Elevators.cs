using System;
using System.Collections.Generic;

namespace Rocket_REST_API.Models
{
    public partial class Elevators
    {
        public long Id { get; set; }
        public long ColumnId { get; set; }
        public string SerialNumber { get; set; }
        public string ModelType { get; set; }
        public string Status { get; set; }
        public DateTime? DateOfInstallation { get; set; }
        public DateTime? DateOfInspection { get; set; }
        public string InspectionCertificate { get; set; }
        public string Information { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Columns Column { get; set; }
    }
}
