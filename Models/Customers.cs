using System;
using System.Collections.Generic;

namespace Rocket_REST_API.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Buildings = new HashSet<Buildings>();
            Leads = new HashSet<Leads>();
        }

        public long Id { get; set; }
        public long? AddressId { get; set; }
        public long? UserId { get; set; }
        public DateTime? DateOfCreation { get; set; }
        public string CompanyName { get; set; }
        public string FullNameContactPerson { get; set; }
        public string PhoneNumberContactPerson { get; set; }
        public string EmailContactPerson { get; set; }
        public string CompanyDescription { get; set; }
        public string FullNameServicePerson { get; set; }
        public string PhoneNumberServicePerson { get; set; }
        public string EmailServicePerson { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Buildings> Buildings { get; set; }
        public virtual ICollection<Leads> Leads { get; set; }
    }
}
