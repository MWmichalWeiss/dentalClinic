namespace practikumProject.Models
{
    public class RoleEmployeePostModel
    {
       // public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }
        public DateTime EntryDate { get; set; }
        public bool Status { get; set; }
    }
}
