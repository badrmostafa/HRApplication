using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRApplication.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        [ForeignKey("Governorate")]
        public int BirthGovernorateId { get; set; }

        [ForeignKey("Neighborhood")]
        public int BirthNeighborhoodId { get; set; }

        [ForeignKey("CareerField")]
        public int? CareerFieldId { get; set; }

        public string Address { get; set; }

        [ForeignKey("CompanyJob")]
        public int? CompanyJobId { get; set; }

        //navigation property
        public virtual Governorate Governorate { get; set; }
        public virtual Neighborhood Neighborhood { get; set; }
        public virtual CareerField CareerField { get; set; }
        public virtual CompanyJob CompanyJob { get; set; }
        public virtual List<EmployeeQualification> EmployeeQualifications { get; set; }
    }
}