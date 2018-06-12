using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyJob.Models
{
    public class ClikeJS
    {   public int ID { get; set; } 
        [Key]
        public JobSeeker JobOfferId { get; set; }
        [Key]
        public JobSeeker JobSeekerId { get; set; }
        public bool Like { get; set; }
    }
}