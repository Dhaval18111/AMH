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
    public abstract class AbstractAdmin
    {
        public long Id { get; set; }
        public long Type { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        public int Gender { get; set; }
        public int AdminTypeId { get; set; }
        public string AdminTypeName { get; set; }
        public bool IsActive { get; set; }
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

    public abstract class AbstractAdminType
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}

