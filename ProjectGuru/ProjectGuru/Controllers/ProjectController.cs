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
        private ProjectRepository projectRepo = new ProjectRepository(new DataBase());

        [HttpGet]
        public ActionResult Index()
        {
            return View(projectRepo.GetAll());
        }

        [HttpGet]
        public ActionResult Details(string name)
        {
            return View(projectRepo.Find(name));
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
                projectRepo.Add(Project);
                projectRepo.Persist();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string name)
        {
            return View(projectRepo.Find(name));
        }

        [HttpPost]
        public ActionResult Edit(string name, Project updated)
        {
            try
            {
                Project Project = projectRepo.Find(name);
                Project.Description = updated.Description;
                projectRepo.Persist();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(string name)
        {
            return View(projectRepo.Find(name));
        }

        [HttpPost]
        public ActionResult Delete(string name,FormCollection form)
        {
            try
            {
                projectRepo.Remove(name);
                projectRepo.Persist();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}
