using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyJob.Models
{

    public class JobSeekerSearchLogic
    {
        private EasyJobContext db = new EasyJobContext();
        public IQueryable<JobSeeker> GetJobSeeker(JobSeekerSearchModel searchModel)
        {
            var result = db.JobSeekers.AsQueryable();
            if (searchModel != null)
            {
                if (searchModel.Id.HasValue)
                    result = result.Where(x => x.Id == searchModel.Id);

                if (!string.IsNullOrEmpty(searchModel.Ville.Nom))
                    result=result.Where(x => x.Ville.Nom.Equals(searchModel.Ville.Nom));

         
              Ceci est un test


           }
            return result;
        }
    }
}