using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EasyJob.Models
{
    public class JobSeeker
    {
        public int Id { get; set; }

        public User UserId { get; set; }

        [Required]
        public string Email { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage = "This field is required.")]
        public string Username { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public Ville Ville { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }

        public int Age { get; set; }
        [Required]
        public string Diploma { get; set; }

        [Required]
        public int Experience { get; set; }

        public Gender Gender { get; set; }

        [Required]
        public IEnumerable<Photo> Photos { get; set; }


    }
    public enum Gender
    {
        Male,
        Female
    }

}