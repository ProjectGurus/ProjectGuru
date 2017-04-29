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
        public ActionResult Index()
        {
            return View(ActivityRepository.GetInstance().Get());
        }

        [HttpGet]
        public ActionResult Details(string name)
        {
            return View(ActivityRepository.GetInstance().Get().Find(a => a.Name.Equals(name)));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Activity activity)
        {
            try
            {
                ActivityRepository.GetInstance().Add(activity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string name)
        {
            return View(ActivityRepository.GetInstance().Get(name));
        }

        [HttpPost]
        public ActionResult Edit(string name, Activity updated)
        {
            try
            {
                ActivityRepository.GetInstance().Update(updated);
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
            return View(ActivityRepository.GetInstance().Get(name));
        }

        [HttpPost]
        public ActionResult Delete(string name, FormCollection forms)
        {
            try
            {
                ActivityRepository.GetInstance().Remove(name);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
