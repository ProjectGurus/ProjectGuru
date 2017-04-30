using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProjectGuru.Models
{
    public class ProjectRepository : Repository<Project>
    {
        public ProjectRepository(DataBase db) : base(db) { }

        public Project Find(string project)
        {
            return db.Projects.Where(p => p.Name.Equals(project)).Include(p => p.Activities).FirstOrDefault();
        }

        public void Remove(string project)
        {
            Project projectObject = Find(project);
            projectObject.Activities.RemoveAll(a => true);
            base.Remove(project);
        }
    }
}