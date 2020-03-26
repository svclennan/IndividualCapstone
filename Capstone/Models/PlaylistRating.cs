using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Capstone.Models
{
    public class PlaylistRating
    {
        [Key]
        public int PlaylistRatingId { get; set; }


        public string PlaylistUrl { get; set; }
        public bool Rating { get; set; }

        public int MoodTrackerId { get; set; }
    }
}
