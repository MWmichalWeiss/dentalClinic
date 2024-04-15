using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.DTOs
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string DescriptionRool { get; set; }
        public bool IsManager { get; set; }
    }
}
