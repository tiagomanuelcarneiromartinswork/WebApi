using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities.Enums;

namespace WebApi.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public Role Role { get; set; }
        public Platoon Platoon { get; set; }
        public ICollection<Allocation> Allocations { get; set; }

    }
}
