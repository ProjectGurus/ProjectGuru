using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectGuru.Models;

namespace ProjectGuru.ViewModels
{
    public class ActivityListViewModel
    {
        public IEnumerable<Activity> Activities;
        public Project ParentProject;

        public ActivityListViewModel(Project project)
        {
            ParentProject = project;
            Activities = project.Activities;
        }
    }
}