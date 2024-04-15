using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Entities
{
    public class RoleEmployee
    {
        public int Id { get; set; }
        public int EmployeeId  { get; set; }
        public int RoleId { get; set; }
        public DateTime EntryDate { get; set; }
        public bool Status { get; set; }
        public Employee Employee { get; set; }
        public Role Role { get; set; }
    }
}
