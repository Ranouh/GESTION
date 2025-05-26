using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GESTION.model
{
    public class SectionScale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSectionScale {get;set;}

        [Required(ErrorMessage = "scale is required and cannot be empty")]
        public int scale {get;set;}

        [Required(ErrorMessage = "SectionId is required and cannot be empty")]
        public int SectionId {get;set;}
        public virtual Section Section{get;set;}

        [Required(ErrorMessage = "LevelId is required and cannot be empty")]
        public int LevelId {get;set;}
        public virtual Level Level {get;set;}

        [Required(ErrorMessage = "LevelId is required and cannot be empty")]
        public int SubjectId {get;set;}
        public virtual Subject Subject{get;set;}

    }
}