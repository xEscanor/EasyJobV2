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
      
        public int JobSeekerId { get; set; }
      
        public int JobOfferId { get; set; }
        public bool Like { get; set; }

        public JSlikeC (bool Like , int JS , int C)
        {
            this.JobSeekerId = JS;
            this.JobOfferId = C;
            this.Like = Like;
        }
    }
}