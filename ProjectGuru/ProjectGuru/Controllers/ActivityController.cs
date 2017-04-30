using ProjectGuru.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectGuru.Controllers
{
    public class ActivityController : Controller
    {
        private ProjectRepository projectRepository = new ProjectRepository(new DataBase());
        private Repository<Activity> activityRepository = new Repository<Activity>(new DataBase());

        [HttpGet]
        public ActionResult Index(string project)
        {
            ViewBag.Project = project;
            return View(projectRepository.Find(project).Activities);
        }

        [HttpGet]
        public ActionResult Details(string name)
        {
            return View(activityRepository.Find(name));
        }

        [HttpGet]
        public ActionResult Create(string project)
        {
            ViewBag.Project = project;
            return View();
        }

        [HttpPost]
        public ActionResult Create(string project, Activity activity)
        {
            projectRepository.Find(project).Activities.Add(activity);
            projectRepository.Persist();
            return RedirectToAction("Index", new { project = project });
        }

        public ActionResult Edit(string name)
        {
            return View(activityRepository.Find(name));
        }

        [HttpPost]
        public ActionResult Edit(string name, Activity updated)
        {
            try
            {
                Activity activity = activityRepository.Find(name);
                activity.Description = updated.Description;
                activity.Duration = updated.Duration;
                activityRepository.Persist();
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
            return View(activityRepository.Find(name));
        }

        [HttpPost]
        public ActionResult Delete(string name, FormCollection forms)
        {
            try
            {
                activityRepository.Remove(name);
                activityRepository.Persist();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
