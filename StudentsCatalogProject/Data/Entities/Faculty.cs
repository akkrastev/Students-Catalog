using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
     public class Faculty : BaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
