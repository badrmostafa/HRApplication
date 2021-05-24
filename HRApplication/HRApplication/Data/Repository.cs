using HRApplication.Models;
using HRApplication.Models.DataContext;
using HRApplication.ViewModels.EmployeeQualifications;
using HRApplication.ViewModels.Neighborhood;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRApplication.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly HRApplicationContext db;
        private readonly DbSet<T> entity;
        public Repository()
        {
            db = new HRApplicationContext();
            entity = db.Set<T>();
        }
        public void Add(T t)
        {
            entity.Add(t);
            db.SaveChanges();
        }

        public bool isRepeat(Governorate governorate)
        {
            bool r = db.Governorates.Where(g => g.Name == governorate.Name && g.ID != governorate.ID).Any();
            if(r)
            {
                return true;
            }
            return false;
        }
        public bool isRepeat(Neighborhood neighborhood)
        {
            bool r = db.Neighborhoods.Where(n => n.Name == n.Name && n.ID != n.ID).Any();
            if (r)
            {
                return true;
            }
            return false;
        }

        public void Delete(T t)
        {
            entity.Remove(t);
            db.SaveChanges();
        }

        public List<T> GetAll()
        {
            return entity.ToList();
        }

        public T GetById(int? id)
        {
            return entity.Find(id);
        }

        public void Update(T t)
        {
            entity.Attach(t);
            db.Entry(t).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Governorates(ref CreateNeighborhood createNeighborhood)
        {
            List<Governorate> governorates = db.Governorates.ToList();
            createNeighborhood.Governorates = new SelectList(governorates, "ID", "Name");
        }
        public void Governorates(ref EditNeighborhood editNeighborhood)
        {
            List<Governorate> governorates = db.Governorates.ToList();
            editNeighborhood.Governorates = new SelectList(governorates, "ID", "Name");
        }

        public void EmployeeQualificationsLists(ref CreateEmployeeQualification createEmployeeQualification)
        {
            var qualifications = db.Qualifications.ToList();
            var employees = db.Employees.ToList();

            createEmployeeQualification.Employees = new SelectList(employees, "ID", "Name");
            createEmployeeQualification.Qualifications = new SelectList(qualifications, "ID", "Name");
        }

        public void EmployeeQualificationsLists(ref EditEmployeeQualification editEmployeeQualification)
        {
            var qualifications = db.Qualifications.ToList();
            var employees = db.Employees.ToList();

            editEmployeeQualification.Employees = new SelectList(employees, "ID", "Name");
            editEmployeeQualification.Qualifications = new SelectList(qualifications, "ID", "Name");
        }

        public bool isEmployeeQualificationRepeat(CreateEmployeeQualification createEmployeeQualification)
        {
            bool r = db.EmployeeQualifications.Where(eq => eq.EmployeeId == createEmployeeQualification.EmployeeId
            && eq.QualificationId == createEmployeeQualification.QualificationId && eq.ID != createEmployeeQualification.ID).Any();
            if(r)
            {
                return true;
            }
            return false;
        }
        public bool isEmployeeQualificationRepeat(EditEmployeeQualification editEmployeeQualification)
        {
            bool r = db.EmployeeQualifications.Where(eq => eq.EmployeeId == editEmployeeQualification.EmployeeId
            && eq.QualificationId == editEmployeeQualification.QualificationId && eq.ID != editEmployeeQualification.ID).Any();
            if (r)
            {
                return true;
            }
            return false;
        }
    }
}