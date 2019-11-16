using System;
using System.Collections.Generic;

namespace Rocket_REST_API.Models
{
    public partial class Quotes
    {
        public long Id { get; set; }
        public string RangeType { get; set; }
        public string BuildingType { get; set; }
        public int? Units { get; set; }
        public int? Stories { get; set; }
        public int? Basements { get; set; }
        public int? ParkingSpaces { get; set; }
        public int? MaxOccupants { get; set; }
        public int? Hours { get; set; }
        public string FullName { get; set; }
        public string BusinessName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BuildingProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string Message { get; set; }
        public string DepartementInChargeOfElevators { get; set; }
        public int? ElevatorShafts { get; set; }
        public float? ElevatorUnitCost { get; set; }
        public float? SetupFees { get; set; }
        public float? Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
