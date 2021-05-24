using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRApplication.ViewModels.EmployeeQualifications
{
    public class DeleteEmployeeQualification
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public string Governorate { get; set; }
        public string Neighborhood { get; set; }
        public string CareerField { get; set; }
        public string Address { get; set; }
        public string CompanyJob { get; set; }
        public int JobArrangement { get; set; }
        public string Qualification { get; set; }
    }
}