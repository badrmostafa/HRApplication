using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRApplication.Models
{
    public class CompanyJob
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int JobArrangement { get; set; }

        //navigation property
        public virtual List<Employee> Employees { get; set; }
    }
}