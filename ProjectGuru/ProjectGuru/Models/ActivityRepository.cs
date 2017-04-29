using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectGuru.Models
{
    public class ActivityRepository
    {
        private static ActivityRepository Instance;
        public List<Activity> List;

        private ActivityRepository()
        {
            List = new List<Activity>();
        }

        public static ActivityRepository GetInstance()
        {
            return Instance ?? (Instance = new ActivityRepository());
        }
    }
}