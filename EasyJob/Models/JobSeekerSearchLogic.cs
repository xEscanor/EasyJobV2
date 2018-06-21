using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;

namespace EasyJob.Models
{

    public class JobSeekerSearchLogic
    {
        private EasyJobContext db = new EasyJobContext();
        public IQueryable<JobSeeker> GetJobSeeker(JobSeekerSearchModel searchModel,int Offreid)
        {
            var result = db.JobSeekers.AsQueryable();
            if (searchModel != null)
            {
                var test = from p in db.ClikeJSs
                           where p.JobOfferId == Offreid
                           select p.JobSeekerId;
                
               foreach(int element in test)
                    {
                    result = result.Where(x => x.Id != element);
                    };
             

                if (searchModel.Experience.HasValue)
                    result = result.Where(x => x.Experience == searchModel.Experience );

                if (!string.IsNullOrEmpty(searchModel.Ville.Nom))
                    result=result.Where(x => x.Ville.Nom.Equals(searchModel.Ville.Nom));

                if (!string.IsNullOrEmpty(searchModel.Diploma))
                    result = result.Where(x => x.Diploma.Contains(searchModel.Diploma));

                if (searchModel.Age.HasValue)
                    result = result.Where(x => x.Age==searchModel.Age);

               
               
            }
            return result;
        }
    }
}