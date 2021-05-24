using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRApplication.ViewModels.EmployeeQualifications
{
    public class EditEmployeeQualification
    {
        public int ID { get; set; }
        public int EmployeeId { get; set; }
        public int QualificationId { get; set; }
        public SelectList Employees { get; set; }
        public SelectList Qualifications { get; set; }
        public string Message { get; set; }
    }
}