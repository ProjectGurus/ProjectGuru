using ProjectGuru.DataAccess;
using ProjectGuru.Models;
using ProjectGuru.ViewModels;
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
            using (UnitOfWork uow = new UnitOfWork())
            {
                Project parent = uow.Projects.GetWithActivities(projectId);
                return View(new ActivityListViewModel(parent));
            }
        }

        [HttpGet]
        public ActionResult Details(int projectId, int activityId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return View(new ActivityViewModel(uow.Activities.Get(activityId), uow.Projects.Get(projectId)));
            }
        }

        [HttpGet]
        public ActionResult Create(int projectId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Project project = uow.Projects.Get(projectId);
                return View(project);
            }
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
        public ActionResult Edit(int projectId, int activityId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return View(new ActivityViewModel(uow.Activities.Get(activityId), uow.Projects.Get(projectId)));
            }
        }

        [HttpPost]
        public ActionResult Edit(int projectId, ActivityViewModel updated)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Activity activity = uow.Activities.Get(updated.Activity.Id);
                    activity.Name = updated.Activity.Name;
                    activity.Description = updated.Activity.Description;
                    activity.Duration = updated.Activity.Duration;
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
        public ActionResult Delete(int projectId, int activityId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return View(new ActivityViewModel(uow.Activities.Get(activityId), uow.Projects.Get(projectId)));
            }
        }

        [HttpPost]
        public ActionResult Delete(int projectId, int activityId, FormCollection forms)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.Activities.Remove(uow.Activities.Get(activityId));
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
