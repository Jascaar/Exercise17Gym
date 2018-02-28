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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }
        [Required]
        protected decimal duration=0;
        //        [RegularExpression(@"^[0-8]:[0-5][0-9]", ErrorMessage = "Valid format is H:MM, classes cannot be longer than 8:59")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = false)]
        public DateTime Duration { get; set; }
/*        {
            get
            { return DateTime.MinValue.AddHours((int)duration).AddMinutes(((int)(duration - (int)duration))*60);}
            set {duration=value.Hour+value.Minute/60; }
        }*/
        [Display(Name = "End date/time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get { return StartTime.AddHours(Duration.Hour).AddMinutes(Duration.Minute); } }
        [StringLength(100, ErrorMessage = "The {0} must be between {1} and {2} characters long", MinimumLength = 1)]
        public String Description { get; set; }        public virtual ICollection<ApplicationUser> AttendingMembers { get; set; }
    }

    public class UptoEightHoursAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            value = (DateTime)value;
            // This assumes inclusivity, i.e. exactly six years ago is okay
            if (DateTime.MinValue.CompareTo(value) >= 0 && DateTime.MinValue.AddHours(8).CompareTo(value) <= (1/3))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("We don't do gym classes longer than eight hours (see case #4521 for more details)");
            }
        }
    }



}