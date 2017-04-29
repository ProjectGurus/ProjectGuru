using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProjectGuru.Models
{
    public class ActivitiesContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
    }
}