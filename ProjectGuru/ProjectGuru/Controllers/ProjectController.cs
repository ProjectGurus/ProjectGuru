using ProjectGuru.DataAccess;
using ProjectGuru.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectGuru.Controllers
{
    public class ProjectController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return View(uow.Projects.GetAll()); 
            }
        }

        [HttpGet]
        public ActionResult Details(int projectId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return View(uow.Projects.Get(projectId)); 
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Project Project)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.Projects.Add(Project);
                    uow.Complete();
                    return RedirectToAction("Index"); 
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int projectId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return View(uow.Projects.Get(projectId));
            }
        }

        [HttpPost]
        public ActionResult Edit(int projectId, Project updated)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Project project = uow.Projects.Get(projectId);
                    project.Name = updated.Name;
                    project.Description = updated.Description;
                    uow.Complete();
                    return RedirectToAction("Index"); 
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int projectId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return View(uow.Projects.Get(projectId));
            }
        }

        [HttpPost]
        public ActionResult Delete(int projectId, FormCollection form)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.Projects.Remove(uow.Projects.Get(projectId));
                    uow.Complete();
                    return RedirectToAction("Index"); 
                }
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
