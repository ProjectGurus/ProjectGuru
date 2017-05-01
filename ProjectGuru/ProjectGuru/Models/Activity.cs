using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectGuru.Models
{
    public class Activity : IActivity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Duration { get; set; }

        public float EstimatedDuration
        {
            get
            {
                return Duration;
            }
        }
    }
}