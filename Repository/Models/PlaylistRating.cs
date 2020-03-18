﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
    public class PlaylistRating
    {
        [Key]
        public int PlaylistRatingId { get; set; }

        public string PlaylistUrl { get; set; }

        public bool Rating { get; set; }


        [ForeignKey("MoodTracker")]
        public int MoodTrackerId { get; set; }
        public MoodTracker MoodTracker { get; set; }
    }
}
