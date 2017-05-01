using System;
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

        private AppContext AppContext { get { return Context as AppContext; } }

        public IEnumerable<Project> GetAllWithActivities()
        {
            return AppContext.Projects.Include(p => p.Activities);
        }

        public Project GetWithActivities(int projectId)
        {
            return AppContext.Projects.Where(p => p.Id.Equals(projectId)).Include(p => p.Activities).FirstOrDefault();
        }

        public new void Remove(Project project)
        {
            project = GetWithActivities(project.Id);
            AppContext.Activities.RemoveRange(project.Activities);
            AppContext.Projects.Remove(project);
        }
    }
}