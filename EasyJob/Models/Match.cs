using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyJob.Models
{
    public class Match
    {
        public int ID { get; set; }
        [Key]
        public Company CompanyId { get; set; }
        [Key]
        public JobSeeker JobSeekerId { get; set; }
    }
}