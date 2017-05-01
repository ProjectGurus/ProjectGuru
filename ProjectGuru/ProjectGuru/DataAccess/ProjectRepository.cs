﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProjectGuru.Models;

namespace ProjectGuru.DataAccess
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(AppContext context) : base(context) { }

        private AppContext ProjectContext { get { return Context as AppContext; } }

        public IEnumerable<Project> GetAllWithActivities()
        {
            return ProjectContext.Projects.Include(p => p.Activities);
        }

        public Project GetWithActivities(int projectId)
        {
            return ProjectContext.Projects.Where(p => p.Id.Equals(projectId)).Include(p => p.Activities).FirstOrDefault();
        }
    }
}