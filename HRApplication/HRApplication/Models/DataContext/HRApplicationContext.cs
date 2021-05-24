using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HRApplication.Models.DataContext
{
    public class HRApplicationContext : DbContext
    {
        //constructor with connection string name
        public HRApplicationContext():base("name=HRApplicationConnection")
        {
        
        }

        //tables in database
        public DbSet<CareerField> CareerFields { get; set; }
        public DbSet<CompanyJob> CompanyJobs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeQualification> EmployeeQualifications { get; set; }
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
 

    }
}