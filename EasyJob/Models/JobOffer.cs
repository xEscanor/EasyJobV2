using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EasyJob.Models
{
    public class JobOffer
    {
        public Company Company { get; set; }

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Diploma { get; set; }

        [Required]
        public int Experience { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        public Profil Profil { get; set; }

        //foreign key
        [Required]
        public FieldOfActivity FieldOfActivity { get; set; }

        //foreign key
        [Required]
        public Ville Ville { get; set; }

        [Required]
        public Typee Type { get; set; }


    }
    public enum Typee
    {
        CDI = 1,
        CDD = 2,
        Stage = 3
    }
    public enum Profil
    {
        Cadre,
        Stagiaire,
        Apprenti,
        Technicien,
        Directeur,
        Chercheur
    }

    public enum FieldOfActivity
    {
        test,
        test2
    }
}