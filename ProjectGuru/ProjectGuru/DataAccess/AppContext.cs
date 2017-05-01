using System.Data.Entity;

namespace ProjectGuru.Models
{
    public class AppContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Project> Projects { get; set; }

        public AppContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    }
}