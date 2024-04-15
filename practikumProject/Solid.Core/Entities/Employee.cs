using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Entities
{
    public enum EGender { Male,Female };
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName  { get; set; }
        public string LastName { get; set; }
        public string Tz { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateStartWork { get; set; }
        public  EGender Gander { get; set; }
        public bool Status { get; set; }
        public List<RoleEmployee> Roles { get; set; }
    }
}