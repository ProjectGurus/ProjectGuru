using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectGuru.Models
{
    public class ActivityRepository
    {
        private static ActivityRepository Instance;

        private ActivityRepository() { }

        public static ActivityRepository GetInstance()
        {
            return Instance ?? (Instance = new ActivityRepository());
        }

        public List<Activity> GetAll()
        {
            using (ActivitiesContext context = new ActivitiesContext())
            {
                return context.Activities.ToList();
            }
        }

        public void Add(Activity activity)
        {
            using (ActivitiesContext context = new ActivitiesContext())
            {
                context.Activities.Add(activity);
                context.SaveChanges();
            }
        }
    }
}