using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EasyJob.Models
{
    public class JobOffer
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        public Profil ProfilID { get; set; }

        //foreign key
        [Required]
        public FieldOfActivity FieldOfActivityId { get; set; }

        //foreign key
        [Required]
        public Ville VilleId { get; set; }

        [Required]
        public Typee TypeId { get; set; }

       
    }
    public enum Typee
    {
        CDI = 1,
        CDD = 2,
        Stage = 3
    }
}