using System.Data.Entity;

namespace ProjectGuru.Models
{
    public class DataBase : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DataBase()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    }
}