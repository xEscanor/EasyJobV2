using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EasyJob.Models
{
    public class EasyJobContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public EasyJobContext() : base("name=EasyJobContext")
        {
        }

        public System.Data.Entity.DbSet<EasyJob.Models.Company> Companies { get; set; }
        public System.Data.Entity.DbSet<EasyJob.Models.Ville> Villes { get; set; }

        public System.Data.Entity.DbSet<EasyJob.Models.JobSeeker> JobSeekers { get; set; }

        public System.Data.Entity.DbSet<EasyJob.Models.JobOffer> JobOffers { get; set; }

        public System.Data.Entity.DbSet<EasyJob.Models.Author> Authors { get; set; }

        public System.Data.Entity.DbSet<EasyJob.Models.User> Users { get; set; }
        public System.Data.Entity.DbSet<EasyJob.Models.JSlikeJO> JSlikeCs { get; set; }

        public System.Data.Entity.DbSet<EasyJob.Models.ClikeJS> ClikeJSs { get; set; }

        public System.Data.Entity.DbSet<EasyJob.Models.Match> Matches { get; set; }
    }
}
