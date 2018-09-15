using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bikers.Models
{
    public class MyDb
    {
    }

    public class TeamMembers : BaseClass
    {
        [Required]
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Image { get; set; }
        [DisplayName("Phone")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }

    public class News : BaseClass
    {
        public string Heading { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

    }

    public class Events : BaseClass
    {
        public string EventName { get; set; }
        public string Images { get; set; }
        [AllowHtml]
        public string Description { get; set; }
    }

    public class UpcomingEvents : BaseClass
    {
        [DisplayName("Event Name")]
        public string EventName { get; set; }
        public string Images { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        [DisplayName("Event Date")]
        public DateTime EventDate { get; set; }
    }

    public class Gallery : BaseClass
    {
        public string Name { get; set; }
        public string Images { get; set; }
        public string Description { get; set; }
    }

    public class Hotels : BaseClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }

    public class Camps : BaseClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }

    public class BaseClass
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        [DisplayName("Created By")]
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        [DisplayName("Updated By")]
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
        [DisplayName("Deleted By")]
        public String DeletedBy { get; set; }
        public Nullable<DateTime> DeletedOn { get; set; }
        public bool IsActive { get; set; }
        [AllowHtml]
        public string Remarks { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual ApplicationUser usercreatedby { get; set; }
        [ForeignKey("UpdatedBy")]
        public virtual ApplicationUser userupdatedby { get; set; }
        [ForeignKey("DeletedBy")]
        public virtual ApplicationUser userdeletedby { get; set; }

    }

}