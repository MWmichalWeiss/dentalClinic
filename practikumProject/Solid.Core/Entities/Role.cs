using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Entities
{
    public enum ERoleName
    {
        ClinicDirector,
        SurgeryDirector,
        OrthodonticsDirector,
        equipmentManager,
        SurgeryDoctor,
        Orthodontist,
        BasicDoctor,
        HelperDoctor,
        Stazer
    }
    public class Role
    {
        public int Id { get; set; }
        public string DescriptionRole { get; set; }
        public bool IsManager { get; set; }
        public List<RoleEmployee> Employees { get; set; }
    }
}
