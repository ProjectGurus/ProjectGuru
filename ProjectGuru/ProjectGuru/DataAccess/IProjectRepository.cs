using ProjectGuru.Models;
using System.Collections.Generic;

namespace ProjectGuru.DataAccess
{
    public interface IProjectRepository : IRepository<Project>
    {
        Project GetWithActivities(int projectId);
        IEnumerable<Project> GetAllWithActivities();
    }
}