using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectGuru.Models
{
    public class Project
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Activity> Activities { get; set; } = new List<Activity>();
        public Project() { }
    }
}