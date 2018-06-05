using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyJob.Models
{
    public class JobOfferSearchLogic
    {

        private EasyJobContext db = new EasyJobContext();
        public IQueryable<JobOffer> GetJobOffer(JobOfferSearchModel searchModel)
        {
            var result = db.JobOffers.AsQueryable();
            if (searchModel != null)
            {
                if (!string.IsNullOrEmpty(searchModel.Profil))
                    result = result.Where(x => x.Profil.ToString().Equals(searchModel.Profil));

                if (!string.IsNullOrEmpty(searchModel.Ville.Nom))
                    result = result.Where(x => x.Ville.Nom.Equals(searchModel.Ville.Nom));

                if (!string.IsNullOrEmpty(searchModel.Diploma))
                    result = result.Where(x => x.Diploma.Contains(searchModel.Diploma));

                if (!string.IsNullOrEmpty(searchModel.MotCle))
                    result = result.Where(x => x.Title.Contains(searchModel.MotCle) || x.Description.Contains(searchModel.MotCle));

                if (searchModel.Experience.HasValue)
                    result = result.Where(x => x.Experience == searchModel.Experience);

                if (searchModel.Salary.HasValue)
                    result = result.Where(x => x.Salary >= searchModel.Salary);

                if (!string.IsNullOrEmpty(searchModel.FieldOfActivity))
                    result = result.Where(x => x.FieldOfActivity.Nom.Contains(searchModel.FieldOfActivity));

                if (!string.IsNullOrEmpty(searchModel.Type))
                    result = result.Where(x => x.Type.ToString().Equals(searchModel.Type));

                if (!string.IsNullOrEmpty(searchModel.NomC))
                    result = result.Where(x => x.Company.CompanyName.Equals(searchModel.NomC));



            }
            return result;
        }
    }
}