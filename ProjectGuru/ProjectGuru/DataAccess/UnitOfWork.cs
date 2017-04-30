using ProjectGuru.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectGuru.DataAccess
{
    public class UnitOfWork : IDisposable
    {
        private AppContext context;

        public ProjectRepository Projects { get; private set; }
        public Repository<Activity> Activities { get; private set; }

        public UnitOfWork()
        {
            context = new AppContext();
            Projects = new ProjectRepository(context);
            Activities = new Repository<Activity>(context);
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            //context.Dispose();
        }
    }
}