using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EasyJob.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage = "This field is required.")]
        public string Username { get; set; }

        [Required]
        public string CompanyName { get; set; }

        //foreign key
        [Required]
        public Ville VilleId { get; set; }

        //foreign key
        [Required]
        public FieldOfActivity FieldOfActivityId { get; set; }

        [Required]
        public User UserId { get; set; }
    }
}