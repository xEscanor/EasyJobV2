using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EasyJob.Models
{
    public class Photo
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Url { get; set; }
    }
}