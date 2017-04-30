using ProjectGuru.Models;

namespace ProjectGuru.DataAccess
{
    public interface IProjectRepository : IRepository<Project>
    {
        Project GetProjectWithActivities(int projectId);
    }
}