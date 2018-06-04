using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EasyJob.Models
{
    public class Ville
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public int CodePostal { get; set; }
    }
}