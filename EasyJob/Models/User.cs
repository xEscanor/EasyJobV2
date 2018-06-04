using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyJob.Models
{
    public partial class User
    {
        public int UserId { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage="This field is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage="This field is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
     
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public bool IsCompany { get; set; }

        public bool FirstConnexion { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}