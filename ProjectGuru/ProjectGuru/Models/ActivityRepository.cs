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

        public List<Activity> Get()
        {
            using (ActivitiesContext context = new ActivitiesContext())
            {
                return context.Activities.ToList();
            }
        }

        public Activity Get(string name)
        {
            using (ActivitiesContext context = new ActivitiesContext())
            {
                return context.Activities.Find(name);
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

        public void Remove(string name)
        {
            using (ActivitiesContext context = new ActivitiesContext())
            {
                context.Activities.Remove(context.Activities.Find(name));
                context.SaveChanges();
            }
        }

        public void Update(Activity updated)
        {
            using(ActivitiesContext context = new ActivitiesContext())
            {
                Activity activity = context.Activities.Find(updated.Name);
                activity.Description = updated.Description;
                activity.Duration = updated.Duration;
                context.SaveChanges();
            }
        }
    }
}