using ProjectGuru.Models;

namespace ProjectGuru.DataAccess
{
    public interface IProjectRepository : IRepository<Project>
    {
        Project GetWithActivities(int projectId);
    }
}