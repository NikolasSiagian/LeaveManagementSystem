﻿using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Web.Data
{
    public class LeaveType : BaseEntity
    {
        [Column(TypeName = "Nvarchar(150)")]
        public string Name { get; set; } // e.g. Annual Leave, Sick Leave
        public int NumberOfDays { get; set; }

        public List<LeaveAllocation>? LeaveAllocations { get; set; }

    }
}
