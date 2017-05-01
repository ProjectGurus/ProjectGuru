using ProjectGuru.DataAccess;
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
        [HttpGet]
        public ActionResult Index(int projectId)
        {
            ViewBag.ProjectId = projectId;
            using (UnitOfWork uow = new UnitOfWork())
            {
                return View(uow.Projects.GetWithActivities(projectId).Activities);
            }
        }

        [HttpGet]
        public ActionResult Details(int projectId, int id)
        {
            ViewBag.ProjectId = projectId;
            using (UnitOfWork uow = new UnitOfWork())
            {
                return View(uow.Activities.Get(id)); 
            }
        }

        [HttpGet]
        public ActionResult Create(int projectId)
        {
            ViewBag.ProjectId = projectId;
            return View();
        }

        [HttpPost]
        public ActionResult Create(int projectId, Activity activity)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.Projects.GetWithActivities(projectId).Activities.Add(activity);
                uow.Complete();
                return RedirectToAction("Index", new { projectId = projectId }); 
            }
        }

        [HttpGet]
        public ActionResult Edit(int projectId, int id)
        {
            ViewBag.ProjectId = projectId;
            using (UnitOfWork uow = new UnitOfWork())
            {
                return View(uow.Activities.Get(id)); 
            }
        }

        [HttpPost]
        public ActionResult Edit(int projectId, Activity updated)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Activity activity = uow.Activities.Get(updated.Id);
                    activity.Name = updated.Name;
                    activity.Description = updated.Description;
                    activity.Duration = updated.Duration;
                    uow.Complete(); 
                }
                return RedirectToAction("Index", new { projectId = projectId });
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int projectId, int id)
        {
            ViewBag.ProjectId = projectId;
            using (UnitOfWork uow = new UnitOfWork())
            {
                return View(uow.Activities.Get(id)); 
            }
        }

        [HttpPost]
        public ActionResult Delete(int projectId, int id, FormCollection forms)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.Activities.Remove(uow.Activities.Get(id));
                    uow.Complete();
                    return RedirectToAction("Index", new { projectId = projectId }); 
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
