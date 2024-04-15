using Solid.Core.Entities;

namespace practikumProject.Models
{
    public class EmployeePostModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tz { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateStartWork { get; set; }
        public EGender Gander { get; set; }
        public bool Status { get; set; }
    }
}
