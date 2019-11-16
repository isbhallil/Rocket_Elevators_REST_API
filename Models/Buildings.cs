using System;
using System.Collections.Generic;

namespace Rocket_REST_API.Models
{
    public partial class Buildings
    {
        public Buildings()
        {
            Batteries = new HashSet<Batteries>();
            BuildingDetails = new HashSet<BuildingDetails>();
        }

        public long Id { get; set; }
        public long AddressId { get; set; }
        public long CustomerId { get; set; }
        public string FullNameAdminPerson { get; set; }
        public string EmailAdminPerson { get; set; }
        public string PhoneNumberAdminPerson { get; set; }
        public string FullNameTechPerson { get; set; }
        public string EmailTechPerson { get; set; }
        public string PhoneNumberTechPerson { get; set; }
        public int? Floors { get; set; }
        public string BuildingType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual ICollection<Batteries> Batteries { get; set; }
        public virtual ICollection<BuildingDetails> BuildingDetails { get; set; }
    }
}
