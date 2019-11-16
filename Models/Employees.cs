using System;
using System.Collections.Generic;

namespace Rocket_REST_API.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Batteries = new HashSet<Batteries>();
            Interventions = new HashSet<Interventions>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string EncryptedPassword { get; set; }
        public long? UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Batteries> Batteries { get; set; }
        public virtual ICollection<Interventions> Interventions { get; set; }
    }
}
