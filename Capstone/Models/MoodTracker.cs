using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Capstone.Models
{
    public class MoodTracker
    {
        [Key]
        public int MoodTrackerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }
        public string Genre { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public virtual Mood Mood { get; set; }
        public virtual PlaylistRating PlaylistRating { get; set; }
    }
}
