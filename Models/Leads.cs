using System;
using System.Collections.Generic;

namespace Rocket_REST_API.Models
{
    public partial class Leads
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public string FullName { get; set; }
        public string BusinessName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BuildingProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string BuildingType { get; set; }
        public string Message { get; set; }
        public string OriginalFilename { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Customers Customer { get; set; }
    }
}
