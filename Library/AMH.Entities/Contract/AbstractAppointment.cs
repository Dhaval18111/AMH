using AMH;
using AMH.Entities.V1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMH.Entities.Contract
{
    public abstract class AbstractAppointment
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long AssignedTo { get; set; }
        public string ServiceName { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public long Ammount { get; set; }
        public long Duration { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public long Status { get; set; }
        public string StatusName { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime LastLogin { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public long DeletedBy { get; set; }
        [NotMapped]
        public string CreatedDateStr => CreatedDate != null ? CreatedDate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
        [NotMapped]
        public string UpdatedDateStr => UpdatedDate != null ? UpdatedDate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
        [NotMapped]
        public string DeletedDateStr => DeletedDate != null ? DeletedDate.ToString("dd-MMM-yyyy hh:mm tt") : "-";
    }
    public abstract class AbstractMasterAppointmentStatus
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

}

