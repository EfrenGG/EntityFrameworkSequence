using System;
using System.Collections.Generic;

namespace EntityFrameworkSequence.Models.Entities
{
    public partial class Person
    {
        public Person()
        {
            InverseManager = new HashSet<Person>();
        }

        public int Id { get; set; }
        public int? ManagerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; }

        public virtual Person Manager { get; set; }
        public virtual ICollection<Person> InverseManager { get; set; }
    }
}
