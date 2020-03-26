using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Capstone.Models
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }
    }
}
