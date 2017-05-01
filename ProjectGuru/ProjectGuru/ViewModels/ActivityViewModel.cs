using ProjectGuru.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectGuru.ViewModels
{
    public class ActivityViewModel
    {
        public Activity Activity { get; }
        public Project ParentProject { get; }

        public ActivityViewModel(Activity activity, Project parent)
        {
            Activity = activity;
            ParentProject = parent;
        }
    }
}