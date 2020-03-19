using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Capstone.Models
{
    public class Mood
    {
        [Key]
        public int MoodId { get; set; }


        public int? MoodRating { get; set; }
        public string Note { get; set; }
        public DateTime? Date { get; set; }

        public int MoodTrackerId { get; set; }
        public MoodTracker MoodTracker { get; set; }
    }
}
