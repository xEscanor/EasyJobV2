using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyJob.Models
{
    public class JSlikeC
    {
        public int ID { get; set; }
        [Key]
        public JobSeeker JobSeekerId { get; set; }
        [Key]
        public JobOffer JobOfferId { get; set; }
        public bool Like { get; set; }
    }
}