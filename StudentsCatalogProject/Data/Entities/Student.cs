using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
     public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string City { get; set; }

        public int NationalityId { get; set; }
        public virtual Nationality Nationality { get; set; }

        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}
