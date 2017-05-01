using ProjectGuru.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectGuru.ViewModels
{
    public class ActivityViewModel
    {
        public Activity Activity { get; set; }
        public Project ParentProject { get; set; }

        public ActivityViewModel(Activity activity, Project parent)
        {
            Activity = activity;
            ParentProject = parent;
        }

        public ActivityViewModel()
        {

        }
    }
}