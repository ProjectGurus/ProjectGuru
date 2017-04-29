using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectGuru.Models
{
    public class Activity
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public float Duration { get; set; }

        public Activity()
        {
        }
    }
}