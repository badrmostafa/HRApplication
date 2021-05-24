using AutoMapper;
using HRApplication.Data;
using HRApplication.Mapper;
using HRApplication.Models;
using HRApplication.Models.DataContext;
using HRApplication.ViewModels.Governorate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRApplication.Controllers
{
    public class GovernorateController : Controller
    {
        private readonly HRApplicationContext db;
        private readonly AutoMap autoMap;
        private readonly Repository<Governorate> repository;
        private IMapper mapper;
        public GovernorateController()
        {
            db = new HRApplicationContext();
            autoMap = new AutoMap();
            repository = new Repository<Governorate>();
        }
        //get all governorates
        public ActionResult Index()
        {
            List<Governorate> governorates = repository.GetAll();
            mapper = autoMap.Mapper();
            List<GetGovernorate> getGovernorates = mapper.Map<List<GetGovernorate>>(governorates);
            return View(getGovernorates);
        }

        //get details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Governorate governorate = repository.GetById(id);
            if (governorate == null)
            {
                return HttpNotFound();
            }
            mapper = autoMap.Mapper();
            GetGovernorate getGovernorate = mapper.Map<GetGovernorate>(governorate);
            return View(getGovernorate);
        }

        //add governorate
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateGovernorate createGovernorate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mapper = autoMap.Mapper();
                    Governorate governorate = mapper.Map<Governorate>(createGovernorate);
                    bool r = repository.isRepeat(governorate);
                    if (r)
                    {
                        createGovernorate.Message = "Governorate is already exists...";
                        return View(createGovernorate);
                    }
                    repository.Add(governorate);
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

        //update governorate
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Governorate governorate = repository.GetById(id);
            if(governorate == null)
            {
                return HttpNotFound();
            }
            mapper = autoMap.Mapper();
            EditGovernorate editGovernorate = mapper.Map<EditGovernorate>(governorate);
            return View(editGovernorate);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditGovernorate editGovernorate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mapper = autoMap.Mapper();
                    Governorate governorate = mapper.Map<Governorate>(editGovernorate);
                    bool r = repository.isRepeat(governorate);
                    if (r)
                    {
                        editGovernorate.Message = "Governorate is already exists...";
                        return View(editGovernorate);
                    }
                    repository.Update(governorate);
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
        //delete governorate
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Governorate governorate = repository.GetById(id);
            if (governorate == null)
            {
                return HttpNotFound();
            }
            mapper = autoMap.Mapper();
            DeleteGovernorate deleteGovernorate = mapper.Map<DeleteGovernorate>(governorate);
            return View(deleteGovernorate);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteGovernorate deleteGovernorate)
        {
            try
            {
                Governorate governorate = repository.GetById(deleteGovernorate.ID);
                repository.Delete(governorate);
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}