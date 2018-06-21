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
        public int CompanyId { get; set; }
        public int JobSeekerId { get; set; }

        public Match( int C, int JS)
        {
            this.JobSeekerId = JS;
            this.CompanyId = C;
            
        }
    }
}