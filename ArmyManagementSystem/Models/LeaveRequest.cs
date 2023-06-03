using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace ArmyManagementSystem.Models
{
	public class LeaveRequest
	{
		[Key]
		public Guid LeaveRequestId { get; set; }

		[Required]		
		public Guid StaffMemberId { get; set; }

		[ForeignKey("StaffMemberId")]
        public StaffMember StaffMember { get; set; }

		[Required]
		[MaxLength(50)]
		[DisplayName("leave type")]
		public string LeaveType { get; set; }

		[Required]
		[DisplayName("start date")]
		public DateTime StartDate { get; set; }

		[Required]
		[DisplayName("end date")]
		public DateTime EndDate { get; set; }

		[Required]
		[MaxLength(100)]
		[DisplayName("location")]
		public string Location { get; set; }

        [NotMapped]
        [DisplayName("leave days")]
        public int LeaveDays => (int)(EndDate - StartDate).TotalDays;
    }
}

