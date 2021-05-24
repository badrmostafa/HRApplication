using AutoMapper;
using HRApplication.Data;
using HRApplication.Mapper;
using HRApplication.Models;
using HRApplication.Models.DataContext;
using HRApplication.ViewModels.Neighborhood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HRApplication.Controllers
{
    public class NeighborhoodController : Controller
    {

        private readonly HRApplicationContext db;
        private readonly AutoMap autoMap;
        private readonly Repository<Neighborhood> repository;
        private IMapper mapper;
        public NeighborhoodController()
        {
            db = new HRApplicationContext();
            autoMap = new AutoMap();
            repository = new Repository<Neighborhood>();
        }

        //get all neighborhood
        public ActionResult Index()
        {
            List<Neighborhood> neighborhoods = repository.GetAll();
            mapper = autoMap.Mapper();
            List<GetNeighborhood> getNeighborhoods = mapper.Map<List<GetNeighborhood>>(neighborhoods);
            return View(getNeighborhoods);
        }

        //get neighborhood by id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Neighborhood neighborhood = repository.GetById(id);
            if (neighborhood == null)
            {
                return HttpNotFound();
            }
            mapper = autoMap.Mapper();
            GetNeighborhood getNeighborhood = mapper.Map<GetNeighborhood>(neighborhood);
            return View(getNeighborhood);
        }

        //add new neighborhood
        public ActionResult Create()
        {
            CreateNeighborhood createNeighborhood = new CreateNeighborhood();
            repository.Governorates(ref createNeighborhood);
            return View(createNeighborhood);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateNeighborhood createNeighborhood)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mapper = autoMap.Mapper();
                    Neighborhood neighborhood = mapper.Map<Neighborhood>(createNeighborhood);
                    bool r = repository.isRepeat(neighborhood);
                    if (r)
                    {
                        repository.Governorates(ref createNeighborhood);
                        createNeighborhood.Message = "neighborhood already exists...";
                        return View(createNeighborhood);
                    }
                    repository.Add(neighborhood);
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

        //update neighborhood
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Neighborhood neighborhood = repository.GetById(id);
            if (neighborhood == null)
            {
                return HttpNotFound();
            }
            mapper = autoMap.Mapper();
            EditNeighborhood editNeighborhood = mapper.Map<EditNeighborhood>(neighborhood);
            repository.Governorates(ref editNeighborhood);
            return View(editNeighborhood);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditNeighborhood editNeighborhood)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mapper = autoMap.Mapper();
                    Neighborhood neighborhood = mapper.Map<Neighborhood>(editNeighborhood);
                    bool r = repository.isRepeat(neighborhood);
                    if (r)
                    {
                        repository.Governorates(ref editNeighborhood);
                        editNeighborhood.Message = "Neighborhood is already exists...";
                        return View(editNeighborhood);
                    }
                    repository.Update(neighborhood);
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
        
        //delete neighborhood
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neighborhood neighborhood = repository.GetById(id);
            if(neighborhood == null)
            {
                return HttpNotFound();
            }
            mapper = autoMap.Mapper();
            DeleteNeighborhood deleteNeighborhood = mapper.Map<DeleteNeighborhood>(neighborhood);
            return View(deleteNeighborhood);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteNeighborhood deleteNeighborhood)
        {
            try
            {
                Neighborhood neighborhood = repository.GetById(deleteNeighborhood.ID);
                repository.Delete(neighborhood);
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }

    }
}