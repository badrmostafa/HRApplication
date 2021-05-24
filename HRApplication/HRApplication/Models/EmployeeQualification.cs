using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRApplication.Models
{
    public class EmployeeQualification
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Qualification")]
        public int QualificationId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        //navigation property
        public virtual Qualification Qualification { get; set; }
        public virtual Employee Employee { get; set; }
    }
}