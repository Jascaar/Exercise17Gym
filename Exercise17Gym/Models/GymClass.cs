using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercise17Gym.Models
{
    public class GymClass
    {
        public int Id { get; set; }
        [StringLength(100, ErrorMessage = "The {0} must be between {1} and {2} characters long", MinimumLength = 1)]
        [Display(Name = "Class name")]
        public string Name { get; set; }

        [Display(Name = "Start date/time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{yy-MM-dd HH:mm}")]
        public DateTime StartTime { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{HH:mm}")]
        public TimeSpan Duration { get; set; }
        [Display(Name = "End date/time")]
        public DateTime EndTime { get { return StartTime + Duration; } }
        [StringLength(100, ErrorMessage = "The {0} must be between {1} and {2} characters long", MinimumLength = 1)]
        public String Description { get; set; }        public virtual ICollection<ApplicationUser> AttendingMembers { get; set; }
    }
}