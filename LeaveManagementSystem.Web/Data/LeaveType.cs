using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Web.Data
{
    public class LeaveType
    {
        public int Id { get; set; }

        [Column(TypeName = "Nvarchar(150)")]
        public string Name { get; set; } // e.g. Annual Leave, Sick Leave
        public int NumberOfDays { get; set; }

    }
}
