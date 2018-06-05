using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyJob.Models
{
    public class JobOfferSearchModel
    {
        public int? Experience { get; set; }
        public String Profil { get; set; }
        public String Diploma { get; set; }
        public Ville Ville { get; set; }
        public int? Salary { get; set; }
        public String FieldOfActivity { get; set; }
        public String NomC { get; set; }
        public String MotCle { get; set; }
        public String Type { get; set; }
    }
}