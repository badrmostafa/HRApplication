using AutoMapper;
using HRApplication.Data;
using HRApplication.Mapper;
using HRApplication.Models;
using HRApplication.Models.DataContext;
using HRApplication.ViewModels.EmployeeQualifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HRApplication.Controllers
{
    public class EmployeeQualificationController : Controller
    {
        private readonly HRApplicationContext db;
        private readonly AutoMap autoMap;
        private readonly Repository<EmployeeQualification> repository;
        private IMapper mapper;
        public EmployeeQualificationController()
        {
            db = new HRApplicationContext();
            autoMap = new AutoMap();
            repository = new Repository<EmployeeQualification>();
        }

        //get employees with qualifications
        public ActionResult Index()
        {
            List<EmployeeQualification> employeeQualifications = repository.GetAll();
            IOrderedEnumerable<EmployeeQualification> employeeQualificationsOrdered = employeeQualifications.OrderBy(o => o.Employee.CompanyJob.JobArrangement);
            mapper = autoMap.Mapper();
            List<GetEmployeeQualification> getEmployeeQualifications = mapper.Map<List<GetEmployeeQualification>>(employeeQualificationsOrdered);
            return View(getEmployeeQualifications);
        }

        //details of employees with qualifications
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeQualification employeeQualification = repository.GetById(id);
            if(employeeQualification == null)
            {
                return HttpNotFound();
            }
            mapper = autoMap.Mapper();
            GetEmployeeQualification getEmployeeQualification = mapper.Map<GetEmployeeQualification>(employeeQualification);
            return View(getEmployeeQualification);
        }
        
        //add new employee with qualification
        public ActionResult Create()
        {
            CreateEmployeeQualification createEmployeeQualification = new CreateEmployeeQualification();
            repository.EmployeeQualificationsLists(ref createEmployeeQualification);
            return View(createEmployeeQualification);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEmployeeQualification createEmployeeQualification)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mapper = autoMap.Mapper();
                    var employeeQualification = mapper.Map<EmployeeQualification>(createEmployeeQualification);
                    bool r = repository.isEmployeeQualificationRepeat(createEmployeeQualification);
                    if (r)
                    {
                        repository.EmployeeQualificationsLists(ref createEmployeeQualification);
                        createEmployeeQualification.Message = "Employee With Qualification is already exists...";
                        return View(createEmployeeQualification);
                    }
                    repository.Add(employeeQualification);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        
        //update employee with qualification
        public ActionResult  Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeQualification employeeQualification = repository.GetById(id);
            if(employeeQualification == null)
            {
                return HttpNotFound();
            }
            mapper = autoMap.Mapper();
            EditEmployeeQualification editEmployeeQualification = mapper.Map<EditEmployeeQualification>(employeeQualification);
            repository.EmployeeQualificationsLists(ref editEmployeeQualification);
            return View(editEmployeeQualification);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditEmployeeQualification editEmployeeQualification)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mapper = autoMap.Mapper();
                    EmployeeQualification employeeQualification = mapper.Map<EmployeeQualification>(editEmployeeQualification);
                    bool r = repository.isEmployeeQualificationRepeat(editEmployeeQualification);
                    if (r)
                    {
                        repository.EmployeeQualificationsLists(ref editEmployeeQualification);
                        editEmployeeQualification.Message = "Employee With Qualification is already exists...";
                        return View(editEmployeeQualification);
                    }
                    repository.Update(employeeQualification);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }
        //delete employee with qualification
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeQualification employeeQualification = repository.GetById(id);
            if (employeeQualification == null)
            {
                return HttpNotFound();
            }
            mapper = autoMap.Mapper();
            DeleteEmployeeQualification deleteEmployeeQualification = mapper.Map<DeleteEmployeeQualification>(employeeQualification);
            return View(deleteEmployeeQualification);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteEmployeeQualification deleteEmployeeQualification)
        {
            try
            {
                EmployeeQualification employeeQualification = repository.GetById(deleteEmployeeQualification.ID);
                repository.Delete(employeeQualification);
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }
    }
}